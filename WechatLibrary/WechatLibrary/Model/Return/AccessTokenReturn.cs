using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Return
{
    /// <summary>
    /// AccessToken 返回码。
    /// </summary>
    public partial class AccessTokenReturn : ReturnBase
    {
        private string _accessToken;

        /// <summary>
        /// 领取到的凭证。
        /// </summary>
        [Json(Name="access_token")]
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
        /// 凭证有效时间，单位：秒。
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
    }
}
