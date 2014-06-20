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
    /// LoadImageResults 的摘要说明
    /// </summary>
    public class LoadImageResults : IHttpHandler, IRequiresSessionState
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
                        info = "data base occurred an error, please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                var wechatAccount = query.First();

                var list = wechatAccount.ImageAutoResponseResults.ToList();

                var query2 = wechatAccount.TextMessageMatches.Where(temp => temp.Id.ToString() == currentTextMatchId);

                var selectedId = string.Empty;

                if (query2.Count() == 1)
                {
                    var matchResultMapping = query2.First().MatchResultMapping;
                    if (matchResultMapping != null)
                    {
                        var resultType = matchResultMapping.ResultType;
                        if (resultType.IndexOf("image", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            var query3 =
                                entities.ImageAutoResponseResults.Where(temp => temp.Id == matchResultMapping.ResultId);
                            if (query3.Count() == 1)
                            {
                                selectedId = query3.First().Id.ToString();
                            }
                        }
                    }
                }

                {
                    var responseObj = new
                    {
                        success = true,
                        data = (from temp in list
                                select new
                                {
                                    Id = temp.Id,
                                    ImgName = temp.WechatResource == null ? string.Empty : temp.WechatResource.Name
                                }).ToList(),
                        selectedId = selectedId
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