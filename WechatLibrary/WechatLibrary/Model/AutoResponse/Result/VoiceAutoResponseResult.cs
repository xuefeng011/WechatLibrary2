﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.AutoResponse.Result
{
    /// <summary>
    /// 语音消息自动回复。
    /// </summary>
    public partial class VoiceAutoResponseResult
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
        public string MediaId
        {
            get;
            set;
        }
    }
}
