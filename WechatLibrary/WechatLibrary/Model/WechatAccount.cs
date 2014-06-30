using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.AutoResponse.Match;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Model.UserManagement;

namespace WechatLibrary.Model
{
    /// <summary>
    /// 微信帐号。
    /// </summary>
    public partial class WechatAccount
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

        private string _appId;

        /// <summary>
        /// AppId。
        /// </summary>
        [Required]
        public string AppId
        {
            get
            {
                return _appId;
            }
            set
            {
                _appId = value;
            }
        }

        private string _secret;

        /// <summary>
        /// Secret。
        /// </summary>
        [Required]
        public string Secret
        {
            get
            {
                return _secret;
            }
            set
            {
                _secret = value;
            }
        }

        private string _token;

        /// <summary>
        /// Token。
        /// </summary>
        [Required]
        public string Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
            }
        }

        private string _wechatId;

        /// <summary>
        /// WechatId。
        /// </summary>
        [Required]
        public string WechatId
        {
            get
            {
                return _wechatId;
            }
            set
            {
                _wechatId = value;
            }
        }

        private string _namespace;

        /// <summary>
        /// Namespace，用于匹配 Handler。
        /// </summary>
        public string Namespace
        {
            get
            {
                return _namespace;
            }
            set
            {
                _namespace = value;
            }
        }

        /// <summary>
        /// 是否服务号。
        /// </summary>
        public bool IsServerAccount
        {
            get;
            set;
        }

        private AccessToken _accessToken;

        /// <summary>
        /// 该微信帐号的 AccessToken。
        /// </summary>
        public virtual AccessToken AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                _accessToken = value;
            }
        }

        private List<ReceiveLog.ReceiveLog> _receiveLogs;

        /// <summary>
        /// 该帐号所有记录的消息。
        /// </summary>
        public virtual List<ReceiveLog.ReceiveLog> ReceiveLogs
        {
            get
            {
                _receiveLogs = _receiveLogs ?? new List<ReceiveLog.ReceiveLog>();
                return _receiveLogs;
            }
            set
            {
                _receiveLogs = value;
            }
        }

        private List<TextMessageMatch> _textMessageMatches;

        /// <summary>
        /// 文本消息自动回复匹配集。
        /// </summary>
        public virtual List<TextMessageMatch> TextMessageMatches
        {
            get
            {
                _textMessageMatches = _textMessageMatches ?? new List<TextMessageMatch>();
                return _textMessageMatches;
            }
            set
            {
                _textMessageMatches = value;
            }
        }

        /// <summary>
        /// 图片消息自动回复匹配。
        /// </summary>
        public virtual ImageMessageMatch ImageMessageMatch
        {
            get;
            set;
        }

        private Menu.Menu _menu;

        /// <summary>
        /// 该微信帐号的微信菜单。
        /// </summary>
        public virtual Menu.Menu Menu
        {
            get
            {
                return _menu;
            }
            set
            {
                _menu = value;
            }
        }

        /// <summary>
        /// 该微信帐号拥有的微信资源。
        /// </summary>
        public virtual List<WechatResource> WechatResources
        {
            get;
            set;
        }




        /// <summary>
        /// 匹配后自动回复的图片。
        /// </summary>
        public virtual List<ImageAutoResponseResult> ImageAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 匹配后自动回复的音乐。
        /// </summary>
        public virtual List<MusicAutoResponseResult> MusicAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 匹配后自动回复的图文。
        /// </summary>
        public virtual List<NewsAutoResponseResult> NewsAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 匹配后自动回复的文本。
        /// </summary>
        public virtual List<TextAutoResponseResult> TextAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 匹配后自动回复的视频。
        /// </summary>
        public virtual List<VideoAutoResponseResult> VideoAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 匹配后自动回复的语音。
        /// </summary>
        public virtual List<VoiceAutoResponseResult> VoiceAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 用户资料。
        /// </summary>
        public virtual List<UserInfoReturn> UserInfos
        {
            get;
            set;
        }
    }
}
