using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.AutoResponse.Match
{
    /// <summary>
    /// 图片消息自动匹配。
    /// </summary>
    public partial class ImageMessageMatch
    {
        private Guid _id;

        /// <summary>
        /// 数据库主键。
        /// </summary>
        [Key]
        [ForeignKey("WechatAccount")]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }


        /// <summary>
        /// 映射该图片消息自动回复的内容。
        /// </summary>
        public virtual MatchResultMapping MatchResultMapping
        {
            get;
            set;
        }

        /// <summary>
        /// 拥有该图片消息自动回复的微信帐号。
        /// </summary>
        public virtual WechatAccount WechatAccount
        {
            get;
            set;
        }
    }
}
