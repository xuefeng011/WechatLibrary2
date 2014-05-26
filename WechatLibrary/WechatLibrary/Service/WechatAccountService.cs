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
        public static IList<string> GetAllWechatIds()
        {
            using (WechatEntities entities = new WechatEntities())
            {
                return entities.WechatAccounts.Select(temp => temp.WechatId).ToList();
            }
        }

        /// <summary>
        /// 根据微信帐号获取微信帐号实例。
        /// </summary>
        /// <returns>若存在，则返回微信帐号实例，否则返回 null。</returns>
        public static WechatAccount GetByWechatId(string wechatId)
        {
            if (wechatId == null)
            {
                return null;
            }
            using (WechatEntities entities = new WechatEntities())
            {
                return entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
            }
        }
    }
}
