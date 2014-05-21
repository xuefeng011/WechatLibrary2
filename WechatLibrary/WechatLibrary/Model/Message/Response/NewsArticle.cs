using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 图文消息项。
    /// </summary>
    public partial class NewsArticle
    {
        private string _title;

        /// <summary>
        /// 图文消息标题。
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
        /// 图文消息描述。
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

        private string _picUrl;

        /// <summary>
        /// 图片链接，支持 JPG、PNG 格式，较好的效果为大图 360 * 200，小图 200 * 200。
        /// </summary>
        public string PicUrl
        {
            get
            {
                return _picUrl;
            }
            set
            {
                _picUrl = value;
            }
        }

        private string _url;

        /// <summary>
        /// 点击图文消息跳转链接。
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

        /// <summary>
        /// 序列化图文消息项到 xml。
        /// </summary>
        /// <returns>xml。</returns>
        public string Serialize()
        {
            return string.Format("<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>", Title, Description, PicUrl, Url);
        }
    }
}
