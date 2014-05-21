using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 回复文本消息。
    /// </summary>
    public partial class TextResult : ResponseResultBase
    {
        private string _content;

        /// <summary>
        /// 回复的消息内容（换行：在 content 中能够换行，微信客户端就支持换行显示）。
        /// </summary>
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        public TextResult()
        {
            this.MsgType = "text";
        }

        /// <summary>
        /// 序列化回复消息到 xml。
        /// </summary>
        /// <returns>xml。</returns>
        public override string Serialize()
        {
            return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Content><![CDATA[{4}]]></Content></xml>", ToUserName, FromUserName, CreateTime, MsgType, Content);
        }
    }
}
