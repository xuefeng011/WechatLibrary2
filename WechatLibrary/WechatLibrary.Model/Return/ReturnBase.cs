using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Return
{
    /// <summary>
    /// 微信返回码基类。
    /// </summary>
    public class ReturnBase
    {
        /// <summary>
        /// 返回的错误码。
        /// </summary>
        [Json(Name = "errcode")]
        public int ErrorCode
        {
            get;
            set;
        }

        /// <summary>
        /// 返回的错误信息。
        /// </summary>
        [Json(Name = "errmsg")]
        public string ErrorMessage
        {
            get;
            set;
        }
    }
}
