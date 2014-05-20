using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service.Menu
{
    public class MenuManagement
    {
        public static bool PostToWechatServer(Model.Menu.Menu menu)
        {
            if (menu == null)
            {
                throw new ArgumentNullException("menu");
            }
            if (menu.WechatAccount == null)
            {
                throw new ArgumentException("menu 没有映射微信帐号", "menu");
            }
            string accessToken = menu.WechatAccount.GetAccessToken();

            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";

            url = string.Format(url, accessToken);

            var json = HttpHelper.Post(url, menu.SerializeToJson());

            var returnBase = JsonHelper.Deserialize<ReturnBase>(json);

            if (returnBase.ErrorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
