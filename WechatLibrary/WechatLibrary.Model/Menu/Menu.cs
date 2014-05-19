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
    public class Menu
    {
        private Guid _id;

        /// <summary>
        /// 数据库主键。
        /// </summary>
        [Key]
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
        public List<MenuButton> Buttons
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

        [ForeignKey("Id")]
        public WechatAccount Account
        {
            get;
            set;
        }
    }
}
