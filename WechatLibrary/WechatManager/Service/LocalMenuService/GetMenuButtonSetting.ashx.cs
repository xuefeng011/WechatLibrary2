using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using Ext.Net;
using WechatLibrary.Model;

namespace WechatManager.Service.LocalMenuService
{
    /// <summary>
    /// GetMenuButtonSetting 的摘要说明
    /// </summary>
    public class GetMenuButtonSetting : IHttpHandler,IRequiresSessionState
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

            var btnId = context.Request["Id"];
            if (string.IsNullOrEmpty(btnId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "menu btn id is null!"
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
                        info = "data base occurred an error! please contact manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var wechatAccount = query.First();
                var btnQuery = entities.MenuButtons.Where(temp => temp.Id.ToString() == btnId);
                if (btnQuery.Count() == 1)
                {
                    var result = btnQuery.First();
                    var responseObj = new
                    {
                        success = true,
                        info = "load setting success!",
                        data = new
                        {
                            Id = result.Id,
                            name = result.Name,
                            type = result.Type.ToString().ToLower(),
                            key = result.Key,
                            url = result.Url
                        }
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var subBtnQuery = entities.MenuSubButtons.Where(temp => temp.Id.ToString() == btnId);
                if (subBtnQuery.Count() == 1)
                {
                    var result = subBtnQuery.First();
                    var responseObj = new
                    {
                        success = true,
                        info = "load setting success!",
                        data = new
                        {
                            Id = result.Id,
                            name = result.Name,
                            type = result.Type.ToString().ToLower(),
                            key = result.Key,
                            url = result.Url
                        }
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
                        info = "data base not exist the button!"
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