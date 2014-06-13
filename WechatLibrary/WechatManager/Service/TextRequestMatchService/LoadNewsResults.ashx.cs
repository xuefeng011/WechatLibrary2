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

            var currentTextMatchId = context.Request["Id"];
            if (string.IsNullOrEmpty(currentTextMatchId) == true)
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
                        info = "data base occurred an error, the same wechat account wechatid appear more than one times, please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                var wechatAccount = query.First();

                var list = wechatAccount.NewsAutoResponseResults.ToList();

                var query2 = wechatAccount.TextMessageMatches.Where(temp => temp.Id.ToString() == currentTextMatchId);

                var selectedId = string.Empty;

                if (query2.Count() == 1)
                {
                    var matchResultMapping = query2.First().MatchResultMapping;
                    if (matchResultMapping != null)
                    {
                        var resultType = matchResultMapping.ResultType;
                        if (resultType.IndexOf("news", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            var query3 =
                                entities.NewsAutoResponseArticles.Where(temp => temp.Id == matchResultMapping.ResultId);
                            if (query3.Count() == 1)
                            {
                                selectedId = query3.First().Id.ToString();
                            }
                        }
                    }
                }

                {
                    var list2 = from temp in list
                                where temp.NewsAutoResponseArticles.Count() > 0
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
                        data = list3.ToList(),
                        selectId = selectedId
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