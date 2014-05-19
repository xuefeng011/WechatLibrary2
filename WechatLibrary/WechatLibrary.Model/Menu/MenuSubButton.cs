using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Menu
{
    /// <summary>
    /// 微信菜单二级按钮。
    /// </summary>
    public class MenuSubButton : MenuButtonBase
    {
        [Key]
        public Guid Id
        {
            get;
            set;
        }
    }
}
