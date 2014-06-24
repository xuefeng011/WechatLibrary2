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
    /// Send 的摘要说明
    /// </summary>
    public class Send : IHttpHandler, IRequiresSessionState
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

            var responseType = context.Request["Type"];
            var responseResourceId = context.Request["Id"];
            var toUserName = context.Request["ToUserName"];

            if (responseType != "text" && responseType != "image" && responseType != "voice" && responseType != "news")
            {
                var responseObj = new
                {
                    success = false,
                    info = "repsonse type error!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            if (string.IsNullOrEmpty(responseResourceId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select an item to response"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            if (string.IsNullOrEmpty(toUserName) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select a user to send!"
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

                switch (responseType)
                {
                    case "text":
                        {
                            var query2 =
                                wechatAccount.TextAutoResponseResults.Where(temp => temp.Id.ToString() == responseResourceId);
                            var textResult = query2.FirstOrDefault();
                            if (textResult == null)
                            {
                                var responseObj = new
                                {
                                    success = false,
                                    info = "item not exist"
                                };
                                var json = JsonHelper.SerializeToJson(responseObj);
                                context.Response.ContentType = "text/json";
                                context.Response.Write(json);
                                return;
                            }
                            var textJson = WechatLibrary.Service.CustomerServiceMessageService.ConvertToJson(textResult, toUserName);
                            var success = WechatLibrary.Service.CustomerServiceMessageService.Send(wechatAccount, textJson);
                            {
                                var responseObj = new
                                {
                                    success = success,
                                    info = success ? "send success" : "send fail"
                                };
                            }
                            break;
                        }
                    case "image":
                        {
                            break;
                        }
                    case "voice":
                        {
                            break;
                        }
                    case "news":
                        {
                            break;
                        }
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