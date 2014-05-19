using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Menu
{
    public class Menu
    {
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        private List<MenuButton> _buttons;

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
    }
}
