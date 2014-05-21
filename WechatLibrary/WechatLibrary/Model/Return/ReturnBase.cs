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
    public partial class ReturnBase
    {
        private int _errorCode;

        /// <summary>
        /// 返回的错误码。
        /// </summary>
        [Json(Name = "errcode")]
        public int ErrorCode
        {
            get
            {
                return _errorCode;
            }
            set
            {
                _errorCode = value;
            }
        }

        private string _errorMessage;

        /// <summary>
        /// 返回的错误信息。
        /// </summary>
        [Json(Name = "errmsg")]
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }
    }
}
