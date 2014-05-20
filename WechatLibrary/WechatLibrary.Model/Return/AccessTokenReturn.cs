using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Return
{
    public class AccessTokenReturn : ReturnBase
    {
        /// <summary>
        /// 获取到的凭证。
        /// </summary>
        [Json(Name = "access_token")]
        public string AccessToken
        {
            get;
            set;
        }

        /// <summary>
        /// 凭证有效时间，单位：秒。
        /// </summary>
        [Json(Name = "expires_in")]
        public int ExpiresIn
        {
            get;
            set;
        }
    }
}
