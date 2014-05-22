using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.ReveiceLog
{
    /// <summary>
    /// 接收到的消息记录。
    /// </summary>
    public partial class ReceiveLog
    {
        /// <summary>
        /// 数据库主键。
        /// </summary>
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 发送方帐号（一个OpenID）。
        /// </summary>
        public string FromUserName
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

        /// <summary>
        /// 用户消息。
        /// </summary>
        public string XmlSource
        {
            get;
            set;
        }

        /// <summary>
        /// 文本消息的内容，仅文本消息记录，其他消息时为空。
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// 记录该消息的时间。
        /// </summary>
        public DateTime LogTime
        {
            get;
            set;
        }
    }
}
