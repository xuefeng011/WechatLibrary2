using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.Menu;
using WechatLibrary.Model.Return;

namespace WechatManager.Service.WechatServerMenuService
{
    /// <summary>
    /// PostLocalWechatMenu 的摘要说明
    /// </summary>
    public class PostLocalWechatMenu : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string wechatId = context.Session["WechatId"] as string;
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
                        info = "there is something wrong with the data base, please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var wechatAccount = query.First();
                ReturnBase returnBase;
                WechatLibrary.Service.MenuService.PostMenuToWechatServer(wechatAccount, out returnBase);
                if (returnBase.ErrorCode != 0)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = returnBase.ErrorMessage
                    };
                    var responseJson = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(responseJson);
                    return;
                }
                else
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "post local menu to wechat server success!"
                    };
                    var responseJson = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(responseJson);
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