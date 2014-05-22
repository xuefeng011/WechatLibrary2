using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string MusicURL
        {
            get;
            set;
        }

        public string HQMusicUrl
        {
            get;
            set;
        }

        public string ThumbMediaId
        {
            get;
            set;
        }
    }
}
