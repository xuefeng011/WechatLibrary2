using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.Menu;

namespace WechatManager.Service.LocalMenuService
{
    /// <summary>
    /// GetLocalSecondMenu 的摘要说明
    /// </summary>
    public class GetLocalSecondMenu : IHttpHandler, IRequiresSessionState
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

            var parentId = context.Request["Id"];
            if (string.IsNullOrEmpty(parentId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "id is none or empty!"
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
                        info = "there is an error occurred, please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                var wechatAccount = query.First();
                var menu = wechatAccount.Menu;
                if (menu == null)
                {
                    var responseObj = new ArrayList();
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var parentBtnQuery = menu.Buttons.Where(temp => temp.Id.ToString() == parentId);
                if (parentBtnQuery.Count() == 1)
                {
                    var btn = parentBtnQuery.First();
                    var json = JsonHelper.SerializeToJson(btn.SubButtons);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                else
                {
                    var json = JsonHelper.SerializeToJson(new ArrayList());
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