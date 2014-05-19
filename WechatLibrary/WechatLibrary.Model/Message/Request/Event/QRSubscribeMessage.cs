using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request.Event
{
    /// <summary>
    /// 扫描二维码关注事件。
    /// </summary>
    public class QRSubscribeMessage : RequestMessageBase
    {
        /// <summary>
        /// 事件类型，subscribe。
        /// </summary>
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// 事件 KEY 值，qrscene_ 为前缀，后面为二维码的参数值。
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
