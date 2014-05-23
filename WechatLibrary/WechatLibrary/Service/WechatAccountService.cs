using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;

namespace WechatLibrary.Service
{
    /// <summary>
    /// 微信帐号服务。
    /// </summary>
    public partial class WechatAccountService
    {
        /// <summary>
        /// 获取数据库中的所有微信帐号。
        /// </summary>
        /// <returns>所有微信帐号集合。</returns>
        public IList<string> GetAllWechatIds()
        {
            using (WechatEntities entities = new WechatEntities())
            {
                return entities.WechatAccounts.Select(temp => temp.WechatId).ToList();
            }
        }
    }
}
