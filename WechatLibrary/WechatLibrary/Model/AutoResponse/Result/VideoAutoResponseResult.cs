using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.AutoResponse.Result
{
    /// <summary>
    /// 视频消息自动回复。
    /// </summary>
    public partial class VideoAutoResponseResult
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
        /// 通过上传多媒体文件，得到的id。
        /// </summary>
        [Required]
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 视频消息的标题。
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 视频消息的描述。
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 该自动回复创建时间。
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }
    }
}
