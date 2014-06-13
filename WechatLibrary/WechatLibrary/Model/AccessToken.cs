using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model
{
    /// <summary>
    /// AccessToken。
    /// </summary>
    public partial class AccessToken
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

        private string _value;

        /// <summary>
        /// AccessToken 的值。
        /// </summary>
        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(_value) == true || _expiresTime == default(DateTime))
                {
                    while (true)
                    {
                        var accessToken = Service.AccessTokenService.Refresh(WechatAccount);
                        if (accessToken.ErrorCode == 0)
                        {
                            this._value = accessToken.AccessToken;
                            this._expiresTime = DateTime.Now.AddSeconds(accessToken.ExpiresIn).AddMinutes(-5);

                            using (WechatEntities entities = new WechatEntities())
                            {
                                var dbAccessToken = entities.AccessTokens.Where(temp => temp.Id == this.Id).First();
                                dbAccessToken.Value = accessToken.AccessToken;
                                dbAccessToken.ExpiresTime = DateTime.Now.AddSeconds(accessToken.ExpiresIn).AddMinutes(-5);
                                entities.SaveChanges();
                            }
                            break;
                        }
                    }
                }

                return _value;
            }
            set
            {
                _value = value;
            }
        }

        private DateTime _expiresTime;

        /// <summary>
        /// 该 AccessToken 的过期时间。
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
        /// 拥有该 AccessToken 的微信帐号。
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
