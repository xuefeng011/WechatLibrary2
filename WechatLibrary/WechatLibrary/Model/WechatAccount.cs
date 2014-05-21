using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
    }
}
