using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;
using WechatLibrary.Model.UserManagement;

namespace WechatLibrary.Service.UserManagementService
{
    public partial class UserManagementService
    {
        private const string GetUserInfoTemplate = @"https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}";

        /// <summary>
        /// 获取用户信息。
        /// </summary>
        /// <param name="wechatAccount">当前微信帐号。</param>
        /// <param name="code">经过授权获取到的 code。</param>
        /// <param name="userInfoLanguage">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语。</param>
        /// <returns>成功则返回用户信息，失败则返回 null。</returns>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>code</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>code</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 的 AppId 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatAccount</c> 的 AppId 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 的 Secret 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatAccount</c> 的 Secret 为空字符串。</exception>
        /// <exception cref="System.ArgumentException"><c>userInfoLanguage</c> 的值非法。</exception>
        public static OAuth2UserInfoReturn GetUserInfo(WechatAccount wechatAccount, string code, UserInfoLanguage userInfoLanguage)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            return GetUserInfo(wechatAccount.AppId, wechatAccount.Secret, code, userInfoLanguage);
        }

        /// <summary>
        /// 获取用户信息。
        /// </summary>
        /// <param name="appId">当前微信帐号的 AppId。</param>
        /// <param name="secret">当前微信帐号的 Secret。</param>
        /// <param name="code">经过授权获取到的 code。</param>
        /// <param name="userInfoLanguage">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语。</param>
        /// <returns>成功则返回用户信息，失败则返回 null。</returns>
        /// <exception cref="System.ArgumentNullException"><c>appId</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>appId</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>secret</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>secret</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>code</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>code</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentException"><c>userInfoLanguage</c> 的值非法。</exception>
        public static OAuth2UserInfoReturn GetUserInfo(string appId, string secret, string code, UserInfoLanguage userInfoLanguage)
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
                throw new ArgumentException("secret 不能为空字符串！", "secret");
            }
            if (code == null)
            {
                throw new ArgumentNullException("code");
            }
            if (code == string.Empty)
            {
                throw new ArgumentException("code 不能为空字符串！", "code");
            }
            // 测试 userInfoLanguag 是否合法。
            userInfoLanguage.GetValue();

            var oAuth2AccessToken = GetOAuth2AccessToken(appId, secret, code);
            if (oAuth2AccessToken.ErrorCode == 0)
            {
                var url = string.Format(GetUserInfoTemplate, oAuth2AccessToken.AccessToken, oAuth2AccessToken.OpenId,
                    userInfoLanguage.GetValue());
                var json = HttpHelper.Get(url);
                return JsonHelper.Deserialize<OAuth2UserInfoReturn>(json);
            }
            else
            {
                return default(OAuth2UserInfoReturn);
            }
        }

        /// <summary>
        /// 获取用户信息。
        /// </summary>
        /// <param name="wechatAccount">当前微信帐号。</param>
        /// <param name="code">经过授权获取到的 code。</param>
        /// <returns>成功则返回用户信息，失败则返回 null。</returns>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>code</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>code</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 的 AppId 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatAccount</c> 的 AppId 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 的 Secret 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatAccount</c> 的 Secret 为空字符串。</exception>
        public static OAuth2UserInfoReturn GetUserInfo(WechatAccount wechatAccount, string code)
        {
            return GetUserInfo(wechatAccount, code, UserInfoLanguage.ZhCn);
        }

        /// <summary>
        /// 获取用户信息。
        /// </summary>
        /// <param name="appId">当前微信帐号的 AppId。</param>
        /// <param name="secret">当前微信帐号的 Secret。</param>
        /// <param name="code">经过授权获取到 code。</param>
        /// <returns>成功则返回用户信息，失败则返回 null。</returns>
        /// <exception cref="System.ArgumentNullException"><c>appId</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>appId</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>secret</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>secret</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>code</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>code</c> 为空字符串。</exception>
        public static OAuth2UserInfoReturn GetUserInfo(string appId, string secret, string code)
        {
            return GetUserInfo(appId, secret, code, UserInfoLanguage.ZhCn);
        }
    }
}
