using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.AutoResponse.Result
{
    /// <summary>
    /// 图文消息自动回复。
    /// </summary>
    public partial class NewsAutoResponseResult
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

        public virtual List<NewsAutoResponseArticle> NewsAutoResponseArticles
        {
            get;
            set;
        }
    }
}
