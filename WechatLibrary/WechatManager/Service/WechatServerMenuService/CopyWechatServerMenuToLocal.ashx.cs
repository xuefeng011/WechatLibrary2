using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;

namespace WechatManager.Service.WechatServerMenuService
{
    /// <summary>
    /// CopyWechatServerMenuToLocal 的摘要说明
    /// </summary>
    public class CopyWechatServerMenuToLocal : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var wechatId = context.Session["WechatId"] as string;
            if (string.IsNullOrEmpty(wechatId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please login again!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            using (var entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.WechatId == wechatId);
                if (query.Count() <= 0)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "please login again!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                if (query.Count() > 1)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "there is a error occurred in data base, please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var wechatAccount = query.First();
                ReturnBase returnBase;
                WechatLibrary.Service.MenuService.CopyWechatServerMenuToLocal(wechatAccount, out returnBase);
                if (returnBase.ErrorCode == 0)
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "copy the menu on wechat server to local data base success!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                else
                {
                    var responseObj = new
                    {
                        success = false,
                        info = returnBase.ErrorMessage
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
            }
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