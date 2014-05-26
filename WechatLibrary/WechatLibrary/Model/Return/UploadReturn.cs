using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Return
{
    public partial class UploadReturn:ReturnBase
    {
        private string _type;

        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb，主要用于视频与音乐格式的缩略图）。
        /// </summary>
        [Json(Name = "type")]
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        private string _mediaId;

        /// <summary>
        /// 媒体文件上传后，获取时的唯一标识。
        /// </summary>
        [Json(Name="media_id")]
        public string MediaId
        {
            get
            {
                return _mediaId;
            }
            set
            {
                _mediaId = value;
            }
        }

        private int _createdAt;

        /// <summary>
        /// 媒体文件上传时间戳。
        /// </summary>
        [Json(Name = "created_at")]
        public int CreatedAt
        {
            get
            {
                return _createdAt;
            }
            set
            {
                _createdAt = value;
            }
        }
    }
}
