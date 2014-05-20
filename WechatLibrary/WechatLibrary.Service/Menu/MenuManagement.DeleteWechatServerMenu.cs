using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service.Menu
{
    public partial class MenuManagement
    {
        public static bool DeleteWechatServerMenu(Model.WechatAccount wechatAccount)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }

            string url = @"https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
            url = string.Format(url, wechatAccount.GetAccessToken());

            var json = HttpHelper.Get(url);
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
