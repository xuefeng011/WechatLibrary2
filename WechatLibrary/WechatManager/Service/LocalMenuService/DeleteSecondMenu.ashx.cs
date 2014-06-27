using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary;
using WechatLibrary.Model;

namespace WechatManager.Service.LocalMenuService
{
    /// <summary>
    /// DeleteSecondMenu 的摘要说明
    /// </summary>
    public class DeleteSecondMenu : IHttpHandler, IRequiresSessionState
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

            // The button which need to delete.
            var buttonId = context.Request["Id"];
            if (string.IsNullOrEmpty(buttonId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "the button id could not be null or empty!"
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
                        info = "please contact the manager there is something wrong with the data base!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var subQuery = entities.MenuSubButtons.Where(temp => temp.Id.ToString() == buttonId);
                if (subQuery.Count() == 1)
                {
                    // Found the button, and delete it from data base.
                    entities.MenuSubButtons.Remove(subQuery.First());
                    // Save the change.
                    entities.SaveChanges();
                    var responseObj = new
                    {
                        success = true,
                        info = "delete success!"
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
                        info = "could not found any buttons by id in the data base!"
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