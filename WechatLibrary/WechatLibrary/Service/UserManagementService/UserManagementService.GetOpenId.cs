using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;

namespace WechatLibrary.Service.UserManagementService
{
    public partial class UserManagementService
    {
        /// <summary>
        /// 通过网页授权获取 openid。
        /// </summary>
        /// <param name="appId">当前微信帐号的 AppId。</param>
        /// <param name="secret">当前微信帐号的 Secret。</param>
        /// <param name="code">通过建立网页授权获取到的 code。</param>
        /// <returns>成功则返回用户的 openid，失败则返回空字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>appId</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>appId</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>secret</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>secret</c> 为空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>code</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>code</c> 为空字符串。</exception>
        public static string GetOpenId(string appId, string secret, string code)
        {
            var oAuth2AccessTokenReturn = GetOAuth2AccessToken(appId, secret, code);
            if (oAuth2AccessTokenReturn.ErrorCode == 0)
            {
                return oAuth2AccessTokenReturn.OpenId;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 通过网页授权获取 openid。
        /// </summary>
        /// <param name="wechatAccount">当前微信帐号。</param>
        /// <param name="code">通过建立网页授权获取到的 code。</param>
        /// <returns>成功则返回用户的 openid，失败则返回空字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>wechatAccount</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatAccount</c> 的 AppId 为空或空字符串。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatAccount</c> 的 Secret 为空或空字符串。</exception>
        /// <exception cref="System.ArgumentNullException"><c>code</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>code</c> 为空或空字符串。</exception>
        public static string GetOpenId(WechatAccount wechatAccount, string code)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            if (string.IsNullOrEmpty(wechatAccount.AppId) == true)
            {
                throw new ArgumentException("wechatAccount 的 AppId 不能为空或空字符串。", "wechatAccount");
            }
            if (string.IsNullOrEmpty(wechatAccount.Secret) == true)
            {
                throw new ArgumentException("wechatAccount 的 Secret 不能为空或空字符串。", "wechatAccount");
            }
            if (code == null)
            {
                throw new ArgumentNullException("code");
            }
            if (code == string.Empty)
            {
                throw new ArgumentException("code 不能为空字符串！", "code");
            }
            return GetOpenId(wechatAccount.AppId, wechatAccount.Secret, code);
        }
    }
}
