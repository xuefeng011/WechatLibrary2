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
    public class NewsArticle
    {
        /// <summary>
        /// 图文消息标题。
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 图文消息描述。
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 图片链接，支持 JPG、PNG 格式，较好的效果为大图 360 * 200，小图 200 * 200。
        /// </summary>
        public string PicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 点击图文消息跳转链接。
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        public string Serialize()
        {
            return string.Format("<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>", Title, Description, PicUrl, Url);
        }
    }
}
