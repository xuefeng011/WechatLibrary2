using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Menu;

namespace WechatLibrary.Model
{
    /// <summary>
    /// 微信实体上下文。
    /// </summary>
    public partial class WechatEntities : DbContext
    {
        /// <summary>
        /// 微信帐号。
        /// </summary>
        public DbSet<WechatAccount> WechatAccounts
        {
            get;
            set;
        }

        /// <summary>
        /// AccessToken。
        /// </summary>
        public DbSet<AccessToken> AccessTokens
        {
            get;
            set;
        }

        /// <summary>
        /// 微信菜单。
        /// </summary>
        public DbSet<Menu.Menu> Menus
        {
            get;
            set;
        }
    }
}
