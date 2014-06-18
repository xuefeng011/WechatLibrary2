using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using Ext.Net;
using WechatLibrary.Model;

namespace WechatManager.Service.MessageLogService
{
    /// <summary>
    /// GetAll 的摘要说明
    /// </summary>
    public class GetAll : IHttpHandler, IRequiresSessionState
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

                // Get http request parameters.
                var prms = new StoreRequestParameters(context);

                var messageQuery = wechatAccount.ReceiveLogs.OrderByDescending(temp => temp.LogTime).Skip(prms.Start).Take(prms.Limit).ToList();

                {
                    var responseObj = new
                    {
                        data = (from temp in messageQuery
                                select new
                                {
                                    FromUserName = temp.FromUserName,
                                    RequestId = temp.Id,
                                    RequestType = temp.MsgType,
                                    RequestLogTime = temp.LogTime.ToString("yyyy年MM月dd日HH时mm分ss秒"),
                                    ResponseId = temp.Result == null ? string.Empty : temp.Result.Id.ToString(),
                                    ResponseType = temp.Result == null ? string.Empty : temp.Result.MsgType,
                                    ResponseLogTime = temp.Result == null ? string.Empty : temp.Result.LogTime.ToString("yyyy年MM月dd日HH时mm分ss秒")
                                }).ToList(),
                        total = wechatAccount.ReceiveLogs.Count()
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