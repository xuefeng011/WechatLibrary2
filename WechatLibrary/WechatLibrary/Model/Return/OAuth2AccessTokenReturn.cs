using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Return
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OAuth2AccessTokenReturn : ReturnBase
    {
        private string _accessToken;

        /// <summary>
        /// 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同。
        /// </summary>
        [Json(Name = "access_token")]
        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                _accessToken = value;
            }
        }

        private int _expiresIn;

        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        [Json(Name = "expires_in")]
        public int ExpiresIn
        {
            get
            {
                return _expiresIn;
            }
            set
            {
                _expiresIn = value;
            }
        }

        private string _refreshToken;

        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        [Json(Name = "refresh_token")]
        public string RefreshToken
        {
            get
            {
                return _refreshToken;
            }
            set
            {
                _refreshToken = value;
            }
        }

        private string _openId;

        /// <summary>
        /// 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        [Json(Name = "openid")]
        public string OpenId
        {
            get
            {
                return _openId;
            }
            set
            {
                _openId = value;
            }
        }

        private string _scope;

        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        [Json(Name = "scope")]
        public string Scope
        {
            get
            {
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }

        /*
         access_token	 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
expires_in	 access_token接口调用凭证超时时间，单位（秒）
refresh_token	 用户刷新access_token
openid	 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
scope	 用户授权的作用域，使用逗号（,）分隔
         
         
         */

    }
}
