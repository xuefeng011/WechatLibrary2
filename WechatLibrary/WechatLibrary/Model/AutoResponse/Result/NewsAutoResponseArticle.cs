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

        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string PicUrl
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }
}
