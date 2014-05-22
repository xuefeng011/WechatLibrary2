using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Menu
{
    /// <summary>
    /// 微信菜单。
    /// </summary>
    public partial class Menu
    {
        private Guid _id;

        /// <summary>
        /// 数据库主键。
        /// </summary>
        [Key]
        [ForeignKey("WechatAccount")]
        [Json(Ignore = true)]
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

        private List<MenuButton> _buttons;

        /// <summary>
        /// 一级菜单数组，个数应为 1～3 个。
        /// </summary>
        [Json(Name = "button")]
        public virtual List<MenuButton> Buttons
        {
            get
            {
                _buttons = _buttons ?? new List<MenuButton>();
                return _buttons;
            }
            set
            {
                _buttons = value;
            }
        }

        private WechatAccount _wechatAccount;

        /// <summary>
        /// 拥有该微信菜单的微信帐号。
        /// </summary>
        [Json(Ignore = true)]
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
