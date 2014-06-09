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
    /// SubmitMenuButtonSetting 的摘要说明
    /// </summary>
    public class SubmitMenuButtonSetting : IHttpHandler, IRequiresSessionState
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

            var buttonId = context.Request["Id"];

            if (string.IsNullOrEmpty(buttonId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "button id could not be null or empty!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            var buttonType = context.Request["type"];

            if (buttonType == null)
            {
                var responseObj = new
                {
                    success = false,
                    info = "button type could not be null!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }
            if (buttonType.Equals("click", StringComparison.OrdinalIgnoreCase) == false &&
                buttonType.Equals("view", StringComparison.OrdinalIgnoreCase) == false &&
                buttonType.Equals("none", StringComparison.OrdinalIgnoreCase) == false)
            {
                var responseObj = new
                {
                    success = false,
                    info = "button type error!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            var buttonName = context.Request["name"];
            var buttonKey = context.Request["key"];
            var buttonUrl = context.Request["url"];

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
                        info = "please contact the manager and tell him/her there is something wrong with the data base!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var btnQuery = entities.MenuButtons.Where(temp => temp.Id.ToString() == buttonId);
                if (btnQuery.Count() == 1)
                {
                    var btn = btnQuery.First();
                    if (buttonType.Equals("click", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        btn.Type = MenuButtonType.Click;
                    }
                    else if (buttonType.Equals("view", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        btn.Type = MenuButtonType.View;
                    }
                    else if (buttonType.Equals("none", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        btn.Type = MenuButtonType.None;
                    }
                    else
                    {
                        var responseObj = new
                        {
                            success = false,
                            info = "button type error!"
                        };
                        var json = JsonHelper.SerializeToJson(responseObj);
                        context.Response.ContentType = "text/json";
                        context.Response.Write(json);
                        return;
                    }
                    btn.Name = buttonName;
                    btn.Key = buttonKey;
                    btn.Url = buttonUrl;
                    if (entities.SaveChanges() > 0)
                    {
                        var responseObj = new
                        {
                            success = false,
                            info = "save button setting success!"
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
                            info = "save button setting fail!"
                        };
                        var json = JsonHelper.SerializeToJson(responseObj);
                        context.Response.ContentType = "text/json";
                        context.Response.Write(json);
                        return;
                    }
                }
                var subBtnQuery = entities.MenuSubButtons.Where(temp => temp.Id.ToString() == buttonId);
                if (subBtnQuery.Count() == 1)
                {
                    var btn = subBtnQuery.First();
                    if (buttonType.Equals("click", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        btn.Type = MenuButtonType.Click;
                    }
                    else if (buttonType.Equals("view", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        btn.Type = MenuButtonType.View;
                    }
                    else if (buttonType.Equals("none", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        btn.Type = MenuButtonType.None;
                    }
                    else
                    {
                        var responseObj = new
                        {
                            success = false,
                            info = "button type error!"
                        };
                        var json = JsonHelper.SerializeToJson(responseObj);
                        context.Response.ContentType = "text/json";
                        context.Response.Write(json);
                        return;
                    }
                    btn.Name = buttonName;
                    btn.Key = buttonKey;
                    btn.Url = buttonUrl;
                    var count = entities.SaveChanges();
                    {
                        var responseObj = new
                        {
                            success = false,
                            info = "save button setting success!"
                        };
                        var json = JsonHelper.SerializeToJson(responseObj);
                        context.Response.ContentType = "text/json";
                        context.Response.Write(json);
                        return;
                    }
                }
                else
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "this button is not exist in the data base!"
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