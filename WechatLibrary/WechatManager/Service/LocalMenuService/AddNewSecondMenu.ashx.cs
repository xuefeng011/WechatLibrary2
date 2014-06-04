using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using Ext.Net;
using WechatLibrary.Model;
using WechatLibrary.Model.Menu;

namespace WechatManager.Service.LocalMenuService
{
    /// <summary>
    /// AddNewSecondMenu 的摘要说明
    /// </summary>
    public class AddNewSecondMenu : IHttpHandler, IRequiresSessionState
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

            var parentId = context.Request["Id"];
            if (string.IsNullOrEmpty(parentId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "parent button id is null or empty!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            var name = context.Request["name"];
            if (string.IsNullOrEmpty(name) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "button name could not be null or empty!"
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
                        info = "please contact the manager, there is something wrong with the data base!"
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
                    wechatAccount.Menu = new WechatLibrary.Model.Menu.Menu(){Id = Guid.NewGuid()};
                    entities.SaveChanges();
                    menu = wechatAccount.Menu;
                }
                
                var btnQuery = menu.Buttons.Where(temp => temp.Id.ToString() == parentId);
                if (btnQuery.Count() <= 0)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "button not exist!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                if (btnQuery.Count() > 1)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "data base occurred an error!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var parentBtn = btnQuery.First();
                if (parentBtn.SubButtons == null)
                {
                    parentBtn.SubButtons = new List<MenuSubButton>();
                    entities.SaveChanges();
                }
                if (parentBtn.SubButtons.Count >= 5)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "second level button count must less than 6!"
                    };
                }
                var newButton = entities.MenuSubButtons.Create();
                newButton.Id = Guid.NewGuid();
                newButton.Name = name;
                newButton.Type = MenuButtonType.None;
                parentBtn.SubButtons.Add(newButton);
                var count = entities.SaveChanges();
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "add success!"
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