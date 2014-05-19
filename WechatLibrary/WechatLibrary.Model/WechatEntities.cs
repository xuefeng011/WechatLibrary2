using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model
{
    public class WechatEntities : DbContext
    {
        public DbSet<WechatAccount> WechatAccounts
        {
            get;
            set;
        }

        public DbSet<Menu.Menu> Menus
        {
            get;
            set;
        }
    }
}
