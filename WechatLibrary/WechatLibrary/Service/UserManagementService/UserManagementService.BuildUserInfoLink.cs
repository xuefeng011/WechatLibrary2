using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Handlers;
using WechatLibrary.Model;

namespace WechatLibrary.Service.UserManagementService
{
    public partial class UserManagementService
    {
        private const string UserInfoLinkTemplate = @"
https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state={2}#wechat_redirect";

        /// <summary>
        /// 建立一条弹出授权页面的链接，可通过 openid 拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息。
        /// </summary>
        /// <param name="wechatAccount">需要建立授权链接的微信帐号。</param>
        /// <param name="redirectUri">授权后重定向的回调链接地址。</param>
        /// <param name="state">重定向后会带上 state 参数，开发者可以填写 a-zA-Z0-9 的参数值。</param>
        /// <returns>能获取用户信息的页面链接。</returns>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatAccount</c> 的 AppId 为 null 或空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>redirectUri</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>redirectUri</c> 不能为空字符串。</exception>
        public static string BuildUserInfoLink(WechatAccount wechatAccount, string redirectUri, string state)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            if (string.IsNullOrEmpty(wechatAccount.AppId)==true)
            {
                throw new ArgumentException("微信帐号的 AppId 不能空或空字符串！", "wechatAccount");
            }
            return BuildUserInfoLink(wechatAccount.AppId, redirectUri, state);
        }

        /// <summary>
        /// 建立一条弹出授权页面的链接，可通过 openid 拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息。
        /// </summary>
        /// <param name="wechatAccount">需要建立授权链接的微信帐号。</param>
        /// <param name="redirectUri">授权后重定向的回调链接地址。</param>
        /// <returns>能获取用户信息的页面链接。</returns>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatAccount</c> 的 AppId 为 null 或空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>redirectUri</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>redirectUri</c> 不能为空字符串。</exception>
        public static string BuildUserInfoLink(WechatAccount wechatAccount, string redirectUri)
        {
            return BuildUserInfoLink(wechatAccount, redirectUri, string.Empty);
        }

        /// <summary>
        /// 建立一条弹出授权页面的链接，可通过 openid 拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息。
        /// </summary>
        /// <param name="appId">需要建立授权链接的微信帐号的 AppId。</param>
        /// <param name="redirectUri">授权后重定向的回调链接地址。</param>
        /// <param name="state">重定向后会带上 state 参数，开发者可以填写 a-zA-Z0-9 的参数值。</param>
        /// <returns>能获取用户信息的页面链接。</returns>
        /// <exception cref="System.ArgumentNullException"><c>appId</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>appId</c> 不能为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>redirectUri</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>redirectUri</c> 不能为空字符串。</exception>
        public static string BuildUserInfoLink(string appId, string redirectUri, string state)
        {
            if (appId == null)
            {
                throw new ArgumentNullException("appId");
            }
            if (appId == string.Empty)
            {
                throw new ArgumentException("appId 不能为空字符串。", "appId");
            }
            if (redirectUri == null)
            {
                throw new ArgumentNullException("redirectUri");
            }
            if (redirectUri == string.Empty)
            {
                throw new ArgumentException("redirectUri 不能为空字符串。", "redirectUri");
            }
            redirectUri = HttpUtility.UrlEncode(redirectUri);
            state = state ?? string.Empty;
            return string.Format(UserInfoLinkTemplate, appId, redirectUri, state);
        }

        /// <summary>
        /// 建立一条弹出授权页面的链接，可通过 openid 拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息。
        /// </summary>
        /// <param name="appId">需要建立授权链接的微信帐号的 AppId。</param>
        /// <param name="redirectUri">授权后重定向的回调链接地址。</param>
        /// <returns>能获取用户信息的页面链接。</returns>
        /// <exception cref="System.ArgumentNullException"><c>appId</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>appId</c> 不能为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>redirectUri</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>redirectUri</c> 不能为空字符串。</exception>
        public static string BuildUserInfoLink(string appId, string redirectUri)
        {
            return BuildUserInfoLink(appId, redirectUri, string.Empty);
        }
    }
}
