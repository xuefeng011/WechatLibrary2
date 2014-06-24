using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;

namespace WechatManager.Service.MessageLogService
{
    /// <summary>
    /// LoadNewsResults 的摘要说明
    /// </summary>
    public class LoadNewsResults : IHttpHandler, IRequiresSessionState
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
                    var responseObj =
                        new
                        {
                            success = false,
                            info =
                                "data base occurred an error, the same wechat account wechatid appear more than one times, please contact the manager!"
                        };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                var wechatAccount = query.First();

                var list = wechatAccount.NewsAutoResponseResults.ToList();

                {
                    var list2 = from temp in list
                                where temp.NewsAutoResponseArticles.Any() == true
                                select temp;
                    var list3 = from temp in list2
                                select new
                                {
                                    Id = temp.Id,
                                    Title = temp.NewsAutoResponseArticles.OrderBy(temp2 => temp2.Index).First().Title
                                };

                    var responseObj = new
                    {
                        success = true,
                        data = list3.ToList()
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