using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service.UserManagementService
{
    public partial class UserManagementService
    {
        private const string GetUserListTemplate = @"https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";

        /// <summary>
        /// 获取关注的用户的 openid 列表。
        /// </summary>
        /// <returns>成功则返回关注的用户的 openid 列表，失败则返回一个空的列表。</returns>
        public static IList<string> GetUserList(WechatAccount wechatAccount)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }

            if (wechatAccount.AccessToken == null)
            {
                throw new ArgumentException("微信帐号的 AccessToken 为空。", "wechatAccount");
            }

            string url = string.Format(GetUserListTemplate, wechatAccount.AccessToken.Value, string.Empty);
            string json = HttpHelper.Get(url);

            GetUserListReturn getUserListReturn = JsonHelper.Deserialize<GetUserListReturn>(json);

            if (getUserListReturn.ErrorCode == 0)
            {
                // Success
                return getUserListReturn.Data.OpenId;
            }
            else
            {
                // Failure
                return new List<string>();
            }
        }
    }
}
