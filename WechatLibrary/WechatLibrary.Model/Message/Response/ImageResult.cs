using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 回复图片消息。
    /// </summary>
    public class ImageResult : ResponseResultBase
    {
        /// <summary>
        /// 通过上传多媒体文件，得到的 id。
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }

        public ImageResult()
        {
            this.MsgType = "image";
        }

        public override string Serialize()
        {
            return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Image><MediaId><![CDATA[{4}]]></MediaId></Image></xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId);
        }
    }
}
