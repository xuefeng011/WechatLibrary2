using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Result;

namespace WechatManager.Service.AutoResponseService
{
    /// <summary>
    /// AddNewsResult 的摘要说明
    /// </summary>
    public class AddNewsResult : IHttpHandler, IRequiresSessionState
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

            var title = context.Request["Title"];
            var description = context.Request["Description"];
            var url = context.Request["Url"];
            var picUrl = context.Request["PicUrl"];

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
                        info = "data base error!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var wechatAccount = query.First();
                var newResult = new NewsAutoResponseResult()
                {
                    Id = Guid.NewGuid()
                };
                newResult.NewsAutoResponseArticles = newResult.NewsAutoResponseArticles ?? new List<NewsAutoResponseArticle>();
                newResult.NewsAutoResponseArticles.Add(new NewsAutoResponseArticle()
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Description = description,
                    Url = url,
                    PicUrl = url
                });
                wechatAccount.NewsAutoResponseResults.Add(newResult);
                entities.SaveChanges();
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