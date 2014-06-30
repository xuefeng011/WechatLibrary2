using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.UserManagement;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 记录用户信息。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool LogUserInfo()
        {
            Wechat.FireLogUserInfoStart(this);

            using (WechatEntities entities = new WechatEntities())
            {
                var wechatAccount =
                    entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == this.RequestMessage.ToUserName);
                if (wechatAccount == null)
                {
                    return false;
                }
                if (wechatAccount.IsServerAccount == false)
                {
                    return true;
                }
                var userInfo =
                    wechatAccount.UserInfos.FirstOrDefault(temp => temp.OpenId == this.RequestMessage.FromUserName);
                if (userInfo == null)
                {
                    userInfo = new UserInfoReturn()
                    {
                        Id = Guid.NewGuid(),
                        CreateTime = DateTime.Now,
                        RefreshTime = new DateTime(1970, 1, 1)
                    };
                    wechatAccount.UserInfos.Add(userInfo);
                }
                if (userInfo.RefreshTime.AddDays(5) < DateTime.Now)
                {
                    string json;
                    try
                    {
                        json = HttpHelper.Get(string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", wechatAccount.AccessToken.Value, this.RequestMessage.FromUserName));
                    }
                    catch
                    {
                        return true;
                    }
                    var userInfoReturn = JsonHelper.Deserialize<UserInfoReturn>(json);
                    if (userInfoReturn.ErrorCode != 0)
                    {
                        return true;
                    }
                    userInfo.City = userInfoReturn.City;
                    userInfo.Country = userInfoReturn.Country;
                    userInfo.HeadImgUrl = userInfoReturn.HeadImgUrl;
                    userInfo.Language = userInfoReturn.Language;
                    userInfo.NickName = userInfoReturn.NickName;
                    userInfo.OpenId = userInfoReturn.OpenId;
                    userInfo.Province = userInfoReturn.Province;
                    userInfo.RefreshTime = DateTime.Now;
                    userInfo.Sex = userInfoReturn.Sex;
                    userInfo.Subscribe = userInfoReturn.Subscribe;
                    userInfo.SubscribeTime = userInfoReturn.SubscribeTime;
                    try
                    {
                        entities.SaveChanges();
                    }
                    catch
                    {
                        return true;
                    }
                }
            }

            Wechat.FireLogUserInfoEnd(this);
            return true;
        }
    }
}
