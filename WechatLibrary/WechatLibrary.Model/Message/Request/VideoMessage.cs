using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request
{
    /// <summary>
    /// 视频消息。
    /// </summary>
    public class VideoMessage : RequestMessageBase
    {
        /// <summary>
        /// 视频消息媒体 id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 视频消息缩略图的媒体 id、可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId
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
