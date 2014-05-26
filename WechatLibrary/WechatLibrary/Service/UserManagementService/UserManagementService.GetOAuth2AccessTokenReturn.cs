using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Handlers;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service.UserManagementService
{
    public partial class UserManagementService
    {
        private const string GetOAuth2AccessTokenTemplate = @"https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        internal static OAuth2AccessTokenReturn GetOAuth2AccessToken(string appId, string secret, string code)
        {
            if (appId == null)
            {
                throw new ArgumentNullException("appId");
            }
            if (appId == string.Empty)
            {
                throw new ArgumentException("appId 不能为空字符串！", "appId");
            }
            if (secret == null)
            {
                throw new ArgumentNullException("secret");
            }
            if (secret == string.Empty)
            {
                throw new ArgumentException("secret 不能为空字符！", "secret");
            }
            if (code == null)
            {
                throw new ArgumentNullException("code");
            }
            if (code == string.Empty)
            {
                throw new ArgumentException("code 不能为空子串！", "code");
            }
            string url = string.Format(GetOAuth2AccessTokenTemplate, appId, secret, code);
            string json = HttpHelper.Get(url);
            OAuth2AccessTokenReturn oAuth2AccessTokenReturn = JsonHelper.Deserialize<OAuth2AccessTokenReturn>(json);
            return oAuth2AccessTokenReturn;
        }

        internal static OAuth2AccessTokenReturn GetOAuth2AccessToken(WechatAccount wechatAccount, string code)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            if (string.IsNullOrEmpty(wechatAccount.AppId) == true)
            {
                throw new ArgumentException("wechatAccount 的 AppId 不能为空或空字符串！", "wechatAccount");
            }
            if (string.IsNullOrEmpty(wechatAccount.Secret) == true)
            {
                throw new ArgumentException("wechatAccount 的 Secret 不能为空或空字符串！", "wechatAccount");
            }
            return GetOAuth2AccessToken(wechatAccount.AppId, wechatAccount.Secret, code);
        }
    }
}
