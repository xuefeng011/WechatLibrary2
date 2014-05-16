using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model
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
