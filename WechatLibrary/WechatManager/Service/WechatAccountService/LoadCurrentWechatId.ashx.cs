using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;

namespace WechatManager.Service.WechatAccountService
{
    /// <summary>
    /// LoadCurrentWechatId 的摘要说明
    /// </summary>
    public class LoadCurrentWechatId : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var wechatId = context.Session["WechatId"] as string;
            string json;
            if (string.IsNullOrEmpty(wechatId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    wechatId = string.Empty
                };
                json = JsonHelper.SerializeToJson(responseObj);
            }
            else
            {
                var responseObj = new
                {
                    success = true,
                    wechatId = wechatId
                };
                json = JsonHelper.SerializeToJson(responseObj);
            }
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