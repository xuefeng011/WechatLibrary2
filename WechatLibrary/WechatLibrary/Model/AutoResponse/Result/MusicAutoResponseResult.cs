using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.AutoResponse.Result
{
    /// <summary>
    /// 音乐消息自动回复。
    /// </summary>
    public partial class MusicAutoResponseResult
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
        /// 音乐标题。
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 音乐描述。
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 音乐链接。
        /// </summary>
        public string MusicURL
        {
            get;
            set;
        }

        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐。
        /// </summary>
        public string HQMusicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 缩略图的媒体id，通过上传多媒体文件，得到的id。
        /// </summary>
        public string ThumbMediaId
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
