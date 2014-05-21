using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model
{
    /// <summary>
    /// OAuth2AccessToken。
    /// </summary>
    public partial class OAuth2AccessToken
    {
        private Guid _id;

        /// <summary>
        /// 数据库主键
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

        private WechatAccount _wechatAccount;

        /// <summary>
        /// 拥有该 OAuth2AccessToken 的微信帐号。
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
