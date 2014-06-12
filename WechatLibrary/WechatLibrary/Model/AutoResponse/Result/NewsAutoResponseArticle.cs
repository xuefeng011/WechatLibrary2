using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.AutoResponse.Result
{
    /// <summary>
    /// 图文消息自动回复项。
    /// </summary>
    public partial class NewsAutoResponseArticle
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
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200。
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

        /// <summary>
        /// 代表当前图文消息项的位置，从 0 开始。
        /// </summary>
        public int Index
        {
            get;
            set;
        }
    }
}
