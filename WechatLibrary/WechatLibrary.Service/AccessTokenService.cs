using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service
{
    public static class AccessTokenService
    {
        public static string GetAccessToken(this WechatAccount wechatAccount)
        {
            using (WechatEntities context = new WechatEntities())
            {
                var account = context.WechatAccounts.Where(temp => temp.Id == wechatAccount.Id).FirstOrDefault();
                if (account == null)
                {
                    throw new ArgumentException("该微信帐号不存在数据库中", "wechatAccount");
                }
                var accessToken = account.AccessToken;
                if (accessToken == null)
                {
                    accessToken = new AccessToken()
                    {
                        Id = Guid.NewGuid()
                    };
                    account.AccessToken = accessToken;
                }
                if (string.IsNullOrEmpty(accessToken.Value) || accessToken.ExpiresTime < DateTime.Now)
                {
                    string url = @"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
                    url = string.Format(url, account.AppId, account.Secret);
                    string json = HttpHelper.Get(url);
                    AccessTokenReturn accessTokenReturn = JsonHelper.Deserialize<AccessTokenReturn>(json);
                    if (accessTokenReturn.ErrorCode != 0)
                    {
                        throw new ArgumentException("获取 AccessToken 失败！" + Environment.NewLine + "errcode:" + accessTokenReturn.ErrorCode + Environment.NewLine + "errmsg:" + accessTokenReturn.ErrorMessage);
                    }
                    // 写回 AccessToken。
                    accessToken.Value = accessTokenReturn.AccessToken;
                    // 设置过期时间。
                    accessToken.ExpiresTime = DateTime.Now.AddSeconds(accessTokenReturn.ExpiresIn).AddMinutes(-5);
                    // 保存修改。
                    context.SaveChanges();
                }
                return accessToken.Value;
            }
        }
    }
}
