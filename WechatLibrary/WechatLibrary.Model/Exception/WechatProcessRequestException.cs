using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Exception
{
    public class WechatProcessRequestException : System.Exception
    {
        public WechatProcessRequestException()
            : base()
        {
        }

        public WechatProcessRequestException(System.Exception innerException)
            : base("处理微信请求失败！", innerException)
        {
        }

        public WechatProcessRequestException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
