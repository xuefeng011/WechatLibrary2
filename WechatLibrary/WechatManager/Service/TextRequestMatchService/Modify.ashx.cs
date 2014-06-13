using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse;

namespace WechatManager.Service.TextRequestMatchService
{
    /// <summary>
    /// Modify 的摘要说明
    /// </summary>
    public class Modify : IHttpHandler, IRequiresSessionState
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

            var textMatchId = context.Request["TextMatchId"];
            if (string.IsNullOrEmpty(textMatchId) == true)
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
            var textMatchContent = context.Request["MatchContent"];
            var textMatchOption = context.Request["MatchOption"];
            int textMatchLevel = -1;
            int.TryParse(context.Request["MatchLevel"], out textMatchLevel);
            if (textMatchLevel <= 0)
            {
                var responseObj = new
                {
                    success = false,
                    info = "match level must bigger than zero."
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }
            var responseType = context.Request["ResponseType"];
            Guid responseItemId;
            if (Guid.TryParse(context.Request["ResponseItemId"], out responseItemId) == false)
            {
                var responseObj = new
                {
                    success = false,
                    info = "response item error!"
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
                        info = "data base occurred an error! please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                // Get the account.
                var wechatAccount = query.First();

                var textMatchQuery = wechatAccount.TextMessageMatches.Where(temp => temp.Id.ToString() == textMatchId);
                if (textMatchQuery.Count() < 1)
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
                if (textMatchQuery.Count() > 1)
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
                var textMatch = textMatchQuery.First();
                textMatch.MatchContent = textMatchContent;
                textMatch.MatchOption = textMatchOption;
                textMatch.MatchLevel = textMatchLevel;

                if (textMatch.MatchResultMapping == null)
                {
                    textMatch.MatchResultMapping = new MatchResultMapping()
                    {
                        Id = Guid.NewGuid(),
                        MatchId = textMatch.Id,
                        MatchType = "text"
                    };
                }
                var matchResultMapping = textMatch.MatchResultMapping;
                matchResultMapping.ResultId = responseItemId;
                matchResultMapping.ResultType = responseType;
                entities.SaveChanges();
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "modify text match success!"
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