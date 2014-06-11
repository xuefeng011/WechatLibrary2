using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;

namespace WechatManager.Service.TextRequestMatchService
{
    /// <summary>
    /// GetById 的摘要说明
    /// </summary>
    public class GetById : IHttpHandler, IRequiresSessionState
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

            var queryId = context.Request["Id"];
            if (string.IsNullOrEmpty(queryId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select an item to query!"
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
                try
                {
                    var queryItem = wechatAccount.TextMessageMatches.Where(temp => temp.Id.ToString() == queryId).SingleOrDefault();
                    if (queryItem == null)
                    {
                        var responseObj = new
                        {
                            success = false,
                            info = "please select an item to query!"
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
                            success = true,
                            data = new
                                {
                                    Id = queryItem.Id,
                                    MatchContent = queryItem.MatchContent,
                                    MatchOption = queryItem.MatchOption
                                }
                        };
                        var json = JsonHelper.SerializeToJson(responseObj);
                        context.Response.ContentType = "text/json";
                        context.Response.Write(json);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = ex.ToString()
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