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
    /// GetLocalFirstMenu 的摘要说明
    /// </summary>
    public class GetLocalFirstMenu : IHttpHandler, IRequiresSessionState
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
                        info = "there is something wrong with the data base!"
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
                    wechatAccount.Menu = new Menu();
                    entities.SaveChanges();
                    menu = wechatAccount.Menu;
                }
                var menuButton = menu.Buttons;
                if (menuButton == null)
                {
                    menu.Buttons = new List<MenuButton>();
                    entities.SaveChanges();
                    menuButton = menu.Buttons;
                }
                {
                    var responseObj = from temp in menuButton
                                      select new
                                      {
                                          Id = temp.Id,
                                          name = temp.Name,
                                          type = temp.Type.ToString().ToLower(),
                                          key = temp.Key,
                                          url = temp.Url
                                      };
                    var json = JsonHelper.SerializeToJson(responseObj.ToList());
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