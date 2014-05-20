using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 回复音乐消息。
    /// </summary>
    public class MusicResult : ResponseResultBase
    {
        /// <summary>
        /// 音乐标题。
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 音乐描述。
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 音乐链接。
        /// </summary>
        public string MusicURL
        {
            get;
            set;
        }

        /// <summary>
        /// 高质量音乐链接，WIFI 环境优先使用该链接播放音乐。
        /// </summary>
        public string HQMusicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 缩略图的媒体 id，通过上传多媒体文件，得到的 id。
        /// </summary>
        public string ThumbMediaId
        {
            get;
            set;
        }

        public MusicResult()
        {
            this.MsgType = "music";
        }

        /// <summary>
        /// 序列化回复消息到 xml。
        /// </summary>
        /// <returns>xml。</returns>
        public override string Serialize()
        {
            return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Music><Title><![CDATA[{4}]]></Title><Description><![CDATA[{5}]]></Description><MusicUrl><![CDATA[{6}]]></MusicUrl><HQMusicUrl><![CDATA[{7}]]></HQMusicUrl><ThumbMediaId><![CDATA[{8}]]></ThumbMediaId></Music></xml>", ToUserName, FromUserName, CreateTime, MsgType, Title, Description, MusicURL, HQMusicUrl, ThumbMediaId);
        }
    }
}
