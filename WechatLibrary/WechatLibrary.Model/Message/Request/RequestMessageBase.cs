using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request
{
    /// <summary>
    /// 接收消息基类。
    /// </summary>
    public abstract class RequestMessageBase
    {
        /// <summary>
        /// 开发者微信号。
        /// </summary>
        public string ToUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 发送方帐号（一个 OpenID）。
        /// </summary>
        public string FromUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 消息创建时间（整型）。
        /// </summary>
        public int CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 消息类型。
        /// </summary>
        public string MsgType
        {
            get;
            set;
        }
    }
}
