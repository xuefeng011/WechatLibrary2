﻿using System;
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
    /// AddNewFirstMenu 的摘要说明
    /// </summary>
    public class AddNewFirstMenu : IHttpHandler, IRequiresSessionState
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

            string name = context.Request["name"];
            if (string.IsNullOrEmpty(name) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "the menu name could not be empty."
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
                        info = "data base occurred an error, please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                {
                    var wechatAccount = query.First();
                    var menu = wechatAccount.Menu;
                    if (menu == null)
                    {
                        wechatAccount.Menu = new Menu();
                        entities.SaveChanges();
                        menu = wechatAccount.Menu;
                    }
                    menu.Buttons.Add(new MenuButton()
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Type = MenuButtonType.None
                    });
                    entities.SaveChanges();
                    var responseObj = new
                    {
                        success = true,
                        info = "add success"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
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