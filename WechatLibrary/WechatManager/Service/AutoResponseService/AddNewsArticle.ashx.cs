using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Result;

namespace WechatManager.Service.AutoResponseService
{
    /// <summary>
    /// AddNewsArticle 的摘要说明
    /// </summary>
    public class AddNewsArticle : IHttpHandler, IRequiresSessionState
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

            var messageId = context.Request["MessageId"];
            var title = context.Request["Title"];
            var description = context.Request["Description"];
            var url = context.Request["Url"];
            var picUrl = context.Request["PicUrl"];
            if (string.IsNullOrEmpty(messageId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select an item to add!"
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
                        info = "data base occurred an error!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var wechatAccount = query.First();
                var messageQuery = wechatAccount.NewsAutoResponseResults.Where(temp => temp.Id.ToString() == messageId);
                if (messageQuery.Count() < 1)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "current news message is not exist in the data base!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                if (messageQuery.Count() > 1)
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
                var newsMessage = messageQuery.First();
                if (newsMessage.NewsAutoResponseArticles == null)
                {
                    newsMessage.NewsAutoResponseArticles = new List<NewsAutoResponseArticle>();
                }
                newsMessage.NewsAutoResponseArticles.Add(new NewsAutoResponseArticle()
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Description = description,
                    Url = url,
                    PicUrl = picUrl,
                    Index = newsMessage.NewsAutoResponseArticles.Count
                });
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