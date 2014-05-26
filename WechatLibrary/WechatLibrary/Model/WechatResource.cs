using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Service;

namespace WechatLibrary.Model
{
    /// <summary>
    /// 微信资源。
    /// </summary>
    public partial class WechatResource
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

        private string _mediaId;

        /// <summary>
        /// 该资源的 MediaId。
        /// </summary>
        public string MediaId
        {
            get
            {
                if (string.IsNullOrEmpty(_mediaId) == true
                    || this._expiresTime == default(DateTime)
                    || this._expiresTime < DateTime.Now)
                {
                    var uploadReturn = WechatResourceService.Upload(this);
                    if (uploadReturn.ErrorCode == 0)
                    {
                        this._mediaId = uploadReturn.MediaId;
                        this._expiresTime = DateTime.Now.AddDays(2);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                return _mediaId;
            }
            set
            {
                _mediaId = value;
            }
        }

        private string _type;

        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb）
        /// </summary>
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

        private byte[] _bytes;

        /// <summary>
        /// 媒体文件的内容。
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                return _bytes;
            }
            set
            {
                _bytes = value;
            }
        }

        private string _name;

        /// <summary>
        /// 媒体文件的名字。
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private DateTime _expiresTime;

        /// <summary>
        /// MediaId 的过期时间。
        /// </summary>
        public DateTime ExpiresTime
        {
            get
            {
                return _expiresTime;
            }
            set
            {
                _expiresTime = value;
            }
        }

        private WechatAccount _wechatAccount;

        /// <summary>
        /// 拥有该微信资源的微信帐号。
        /// </summary>
        public virtual WechatAccount WechatAccount
        {
            get
            {
                return _wechatAccount;
            }
            set
            {
                _wechatAccount = value;
            }
        }
    }
}
