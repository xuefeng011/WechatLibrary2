using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;

namespace WechatLibrary.Service.Menu
{
    public class MenuManagement
    {
        public static bool PostToWechatServer(Model.Menu.Menu menu)
        {
#warning not finish

            WechatAccount account = menu.WechatAccount;
            string accessToken = account.AccessToken.Value;



            string urlTemplate = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=ACCESS_TOKEN";



            return false;
        }
    }
}
