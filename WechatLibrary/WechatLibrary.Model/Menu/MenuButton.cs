using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Menu
{
    public class MenuButton : MenuButtonBase
    {
        private Guid _id;

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

        private List<MenuSubButton> _subButtons;

        /// <summary>
        /// 二级菜单数组，个数应为 1～5 个。
        /// </summary>
        [Json(Name = "sub_button", IgnoreNull = true)]
        public List<MenuSubButton> SubButtons
        {
            get
            {
                _subButtons = _subButtons ?? new List<MenuSubButton>();
                return _subButtons;
            }
            set
            {
                _subButtons = value;
            }
        }
    }
}
