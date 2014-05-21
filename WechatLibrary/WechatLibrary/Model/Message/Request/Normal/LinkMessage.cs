using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request.Normal
{
    /// <summary>
    /// 链接消息。
    /// </summary>
    public class LinkMessage : NormalMessageBase
    {
        private string _title;

        /// <summary>
        /// 消息标题。
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        private string _description;

        /// <summary>
        /// 消息描述。
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        private string _url;

        /// <summary>
        /// 消息链接。
        /// </summary>
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
