using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;

namespace WechatManager.Service.MessageLogService
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
                            var query2 = wechatAccount.TextAutoResponseResults.Where(temp => temp.Id.ToString() == responseResourceId);
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
                                var json = JsonHelper.SerializeToJson(responseObj);
                                context.Response.ContentType = "text/json";
                                context.Response.Write(json);
                                return;
                            }
                        }
                    case "image":
                        {
                            var query2 = wechatAccount.ImageAutoResponseResults.Where(temp => temp.Id.ToString() == responseResourceId);
                            var imageResult = query2.FirstOrDefault();
                            if (imageResult == null)
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
                            var imageJson = WechatLibrary.Service.CustomerServiceMessageService.ConvertToJson(imageResult, toUserName);
                            var success = WechatLibrary.Service.CustomerServiceMessageService.Send(wechatAccount, imageJson);
                            {
                                var responseObj = new
                                {
                                    success = success,
                                    info = success ? "send success" : "send fail"
                                };
                                var json = JsonHelper.SerializeToJson(responseObj);
                                context.Response.ContentType = "text/json";
                                context.Response.Write(json);
                                return;
                            }
                        }
                    case "voice":
                        {
                            var query2 = wechatAccount.VoiceAutoResponseResults.Where(temp => temp.Id.ToString() == responseResourceId);
                            var voiceResult = query2.FirstOrDefault();
                            if (voiceResult == null)
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
                            var voiceJson = WechatLibrary.Service.CustomerServiceMessageService.ConvertToJson(voiceResult, toUserName);
                            var success = WechatLibrary.Service.CustomerServiceMessageService.Send(wechatAccount, voiceJson);
                            {
                                var responseObj = new
                                {
                                    success = success,
                                    info = success ? "send success" : "send fail"
                                };
                                var json = JsonHelper.SerializeToJson(responseObj);
                                context.Response.ContentType = "text/json";
                                context.Response.Write(json);
                                return;
                            }
                        }
                    case "news":
                        {
                            var query2 = wechatAccount.NewsAutoResponseResults.Where(temp => temp.Id.ToString() == responseResourceId);
                            var newsResult = query2.FirstOrDefault();
                            if (newsResult == null)
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
                            var newsJson = WechatLibrary.Service.CustomerServiceMessageService.ConvertToJson(newsResult, toUserName);
                            var success = WechatLibrary.Service.CustomerServiceMessageService.Send(wechatAccount, newsJson);
                            {
                                var responseObj = new
                                {
                                    success = success,
                                    info = success ? "send success" : "send fail"
                                };
                                var json = JsonHelper.SerializeToJson(responseObj);
                                context.Response.ContentType = "text/json";
                                context.Response.Write(json);
                                return;
                            }
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
