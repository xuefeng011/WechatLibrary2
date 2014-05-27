using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Serialization.Json;

namespace WechatManager.Service.WechatAccountService
{
    /// <summary>
    /// GetAllWechatId 的摘要说明
    /// </summary>
    public class GetAllWechatId : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var list = WechatLibrary.Service.WechatAccountService.GetAllWechatIds();
            var json = JsonHelper.SerializeToJson(new
            {
                success = true,
                data = list
            });
            context.Response.ContentType = "text/json";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}