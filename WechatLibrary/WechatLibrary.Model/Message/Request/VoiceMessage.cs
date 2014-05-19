using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request
{
    /// <summary>
    /// 语音消息。
    /// </summary>
    public class VoiceMessage : RequestMessageBase
    {
        /// <summary>
        /// 语音消息媒体 id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 语音消息，如 amr，speex 等。
        /// </summary>
        public string Format
        {
            get;
            set;
        }

        /// <summary>
        /// 语音识别结果，UTF8 编码。
        /// </summary>
        public string Recognition
        {
            get;
            set;
        }

        /// <summary>
        /// 消息 id，64 位整型。
        /// </summary>
        public long MsgId
        {
            get;
            set;
        }
    }
}
