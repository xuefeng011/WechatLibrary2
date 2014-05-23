using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.Menu;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public partial class MenuService
    {
        private const string CreateUrlTemplate = @"https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";

        private const string GetUrlTemplate = @"https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}";
       
        private const string DeleteUrlTemplate = @"https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";

        /// <summary>
        /// 推送微信帐号配置的菜单到微信服务器。
        /// </summary>
        /// <param name="wechatAccount">微信帐号。</param>
        /// <param name="returnBase">返回结果。</param>
        /// <returns>是否成功执行。</returns>
        public static bool PostMenuToWechatServer(WechatAccount wechatAccount, out ReturnBase returnBase)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            Menu menu = wechatAccount.Menu;
            if (menu == null)
            {
                throw new ArgumentException("该微信帐号没有配置菜单", "wechatAccount");
            }
            var accessToken = wechatAccount.AccessToken;
            if (accessToken == null)
            {
                wechatAccount.AccessToken = new AccessToken()
                {
                    Id = Guid.NewGuid(),
                    WechatAccount = wechatAccount
                };
            }
            string url = string.Format(CreateUrlTemplate, wechatAccount.AccessToken.Value);
            string data = menu.SerializeToJson();
            var json = HttpHelper.Post(url, data);
            returnBase = JsonHelper.Deserialize<ReturnBase>(json);
            if (returnBase.ErrorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 推送微信帐号配置的菜单到微信服务器。
        /// </summary>
        /// <param name="wechatAccount">微信帐号。</param>
        /// <returns>是否成功执行。</returns>
        public static bool PostMenuToWechatServer(WechatAccount wechatAccount)
        {
            ReturnBase returnBase;
            return PostMenuToWechatServer(wechatAccount, out returnBase);
        }

        /// <summary>
        /// 删除当前在微信服务器上的微信菜单。
        /// </summary>
        /// <param name="wechatAccount">微信帐号。</param>
        /// <param name="returnBase">返回结果。</param>
        /// <returns>是否成功执行。</returns>
        public static bool DeleteWechatServerMenu(WechatAccount wechatAccount, out ReturnBase returnBase)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            var accessToken = wechatAccount.AccessToken;
            if (accessToken == null)
            {
                wechatAccount.AccessToken = new AccessToken()
                {
                    Id = Guid.NewGuid(),
                    WechatAccount = wechatAccount
                };
            }
            var url = string.Format(DeleteUrlTemplate, wechatAccount.AccessToken.Value);
            var json = HttpHelper.Get(url);
            returnBase = JsonHelper.Deserialize<ReturnBase>(json);
            if (returnBase.ErrorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除当前在微信服务器上的微信菜单。
        /// </summary>
        /// <param name="wechatAccount">微信帐号。</param>
        /// <returns>是否成功执行。</returns>
        public static bool DeleteWechatServerMenu(WechatAccount wechatAccount)
        {
            ReturnBase returnBase;
            return DeleteWechatServerMenu(wechatAccount, out returnBase);
        }

        /// <summary>
        /// 复制微信服务器的菜单结构到本地。
        /// </summary>
        /// <param name="wechatAccount">微信帐号。</param>
        /// <param name="returnBase">返回结果。</param>
        /// <returns>是否成功执行。</returns>
        public static bool CopyWechatServerMenuToLocal(WechatAccount wechatAccount,out ReturnBase returnBase)
        {
            if (wechatAccount==null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            var accessToken = wechatAccount.AccessToken;
            if (accessToken == null)
            {
                wechatAccount.AccessToken = new AccessToken()
                {
                    Id = Guid.NewGuid(),
                    WechatAccount = wechatAccount
                };
            }
            string url = string.Format(GetUrlTemplate, wechatAccount.AccessToken.Value);
            var json = HttpHelper.Get(url);
            Menu serverMenu = JsonHelper.Deserialize<Menu>(json);
            serverMenu.Id = Guid.NewGuid();
            for (int i = 0; i < serverMenu.Buttons.Count; i++)
            {
                serverMenu.Buttons[i].Id = Guid.NewGuid();
                for (int j = 0; j < serverMenu.Buttons[i].SubButtons.Count; j++)
                {
                    serverMenu.Buttons[i].SubButtons[j].Id = Guid.NewGuid();
                }
            }
            returnBase = null;
            return true;
        }
    }
}
