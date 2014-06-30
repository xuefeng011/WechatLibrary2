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
    /// 图片消息自动回复。
    /// </summary>
    public partial class ImageAutoResponseResult
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
        /// 该自动回复消息映射的资源。
        /// </summary>
        public virtual WechatResource WechatResource
        {
            get;
            set;
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
