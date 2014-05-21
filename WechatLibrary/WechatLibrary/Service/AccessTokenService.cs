using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service
{
    internal partial class AccessTokenService
    {
        private const string UrlTemplate =
            @"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        internal static AccessTokenReturn Refresh(string appId, string secret)
        {
            string url = string.Format(UrlTemplate, appId, secret);
            string response = HttpHelper.Get(url);
            AccessTokenReturn accessTokenReturn = JsonHelper.Deserialize<AccessTokenReturn>(response);
            return accessTokenReturn;
        }

        internal static AccessTokenReturn Refresh(WechatAccount wechatAccount)
        {
            return Refresh(wechatAccount.AppId, wechatAccount.Secret);
        }
    }
}
