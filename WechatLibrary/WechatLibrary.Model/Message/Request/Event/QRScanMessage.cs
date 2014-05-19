using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request.Event
{
    /// <summary>
    /// 扫描带参数二维码事件。
    /// </summary>
    public class QRScanMessage : RequestMessageBase
    {
        /// <summary>
        /// 事件类型，SCAN。
        /// </summary>
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// 事件 KEY 值，是一个 32 位无符号整数，即创建二维码时的二维码scene_id。
        /// </summary>
        public string EventKey
        {
            get;
            set;
        }

        /// <summary>
        /// 二维码的 ticket，可用来换取二维码图片。
        /// </summary>
        public string Ticket
        {
            get;
            set;
        }
    }
}
