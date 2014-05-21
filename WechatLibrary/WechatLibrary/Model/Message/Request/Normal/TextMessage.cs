using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request.Normal
{
    /// <summary>
    /// 文本消息。
    /// </summary>
    public partial class TextMessage : NormalMessageBase
    {
        private string _content;

        /// <summary>
        /// 文本消息内容。
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
    }
}
