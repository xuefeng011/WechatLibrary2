using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.AutoResponse.Result
{
    /// <summary>
    /// 文本消息自动回复。
    /// </summary>
    public partial class TextAutoResponseResult
    {
        private Guid _id;

        /// <summary>
        /// 数据库主键。
        /// </summary>
        [Key]
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

        private string _content;

        /// <summary>
        /// 自动回复文本消息内容。
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

        /// <summary>
        /// 该自动回复创建时间。
        /// </summary>
        [Json(Ignore = true)]
        public DateTime CreateTime
        {
            get;
            set;
        }
    }
}
