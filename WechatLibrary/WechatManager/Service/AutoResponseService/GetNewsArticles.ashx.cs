﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;

namespace WechatManager.Service.AutoResponseService
{
    /// <summary>
    /// GetNewsArticels 的摘要说明
    /// </summary>
    public class GetNewsArticles : IHttpHandler, IRequiresSessionState
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

            var newsMessageId = context.Request["Id"];
            if (string.IsNullOrEmpty(newsMessageId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select an item to modify!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            using (var entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.WechatId == wechatId);
                if (query.Count() < 1)
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

                var wechatAccount = query.First();
                var newsMessageQuery =
                    wechatAccount.NewsAutoResponseResults.Where(temp => temp.Id.ToString() == newsMessageId);
                if (newsMessageQuery.Count() < 1)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "please select an item to modify!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                if (newsMessageQuery.Count() > 1)
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
                var newsMessage = newsMessageQuery.First();
                if (newsMessage.NewsAutoResponseArticles == null)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "news message error!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                if (newsMessage.NewsAutoResponseArticles.Count() < 1)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "news message error!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var list = newsMessage.NewsAutoResponseArticles.OrderBy(temp => temp.Index).Skip(1);// skip the first.
                {
                    var responseObj = from temp in list
                                      select new
                                      {
                                          Id = temp.Id,
                                          Title = temp.Title,
                                          Description = temp.Description,
                                          Url = temp.Url,
                                          PicUrl = temp.PicUrl
                                      };
                    var json = JsonHelper.SerializeToJson(responseObj.ToList());
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