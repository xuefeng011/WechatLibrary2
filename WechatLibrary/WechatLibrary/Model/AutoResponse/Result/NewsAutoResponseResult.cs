using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.AutoResponse.Result
{
    public partial class NewsAutoResponseResult
    {
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
