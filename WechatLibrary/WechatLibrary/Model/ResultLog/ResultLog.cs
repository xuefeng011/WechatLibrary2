using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WechatLibrary.Model.ResultLog
{
    /// <summary>
    /// 响应消息记录。
    /// </summary>
    public partial class ResultLog
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
        /// 接收方帐号（收到的 OpenID）。
        /// </summary>
        public string ToUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 开发者微信号。
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
        /// 响应消息 XML 原文。
        /// </summary>
        public string XmlSource
        {
            get;
            set;
        }

        /// <summary>
        /// 记录该响应消息的时间。
        /// </summary>
        public DateTime LogTime
        {
            get;
            set;
        }
    }
}
