using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using Common.Serialization.Json;
using WechatLibrary;
using WechatLibrary.Model;

namespace WechatManager.Service.AutoResponseService
{
    /// <summary>
    /// ModifyNewsArticle 的摘要说明
    /// </summary>
    public class ModifyNewsArticle : IHttpHandler, IRequiresSessionState
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

            var modifyNewsArticleId = context.Request["Id"];
            var title = context.Request["Title"];
            var description = context.Request["Description"];
            var url = context.Request["Url"];
            var picUrl = context.Request["PicUrl"];

            if (string.IsNullOrEmpty(modifyNewsArticleId) == true)
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
                        info = "data base occurred an error!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                var modifyQuery = entities.NewsAutoResponseArticles.Where(temp => temp.Id.ToString() == modifyNewsArticleId);
                if (modifyQuery.Count() < 1)
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
                if (modifyQuery.Count() > 1)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "data base primary key error!"
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