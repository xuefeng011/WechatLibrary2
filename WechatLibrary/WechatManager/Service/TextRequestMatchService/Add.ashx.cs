﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using Newtonsoft.Json;
using WechatLibrary;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Match;

namespace WechatManager.Service.TextRequestMatchService
{
    /// <summary>
    /// Add 的摘要说明
    /// </summary>
    public class Add : IHttpHandler, IRequiresSessionState
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

            var matchContent = context.Request["Content"];
            var matchOption = context.Request["Option"];

            if (matchOption == "完全匹配")
            {
                matchOption = "equals";
            }
            if (matchOption == "不区分大小写完全匹配")
            {
                matchOption = "equalsignore";
            }
            if (matchOption == "部分匹配")
            {
                matchOption = "contains";
            }
            if (matchOption == "不区分大小写部分匹配")
            {
                matchOption = "containsignore";
            }

            switch (matchOption)
            {
                case "equals":
                case "equalsignore":
                case "contains":
                case "containsignore": break;
                default:
                    {
                        var responseObj = new
                        {
                            success = false,
                            info = "请选择正确的匹配方式。"
                        };
                        var json = JsonHelper.SerializeToJson(responseObj);
                        context.Response.ContentType = "text/json";
                        context.Response.Write(json);
                        return;
                    }
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
                        info = "please contact the manager, there is an error occurred in data base!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var wechatAccount = query.First();

                // Get current max match level.
                // The new match level will be this value plus 1.
                int maxMatchLevel = 0;
                if (wechatAccount.TextMessageMatches.Count() > 0)
                {
                    maxMatchLevel = wechatAccount.TextMessageMatches.Max(temp => temp.MatchLevel);
                }

                wechatAccount.TextMessageMatches.Add(new TextMessageMatch()
                {
                    Id = Guid.NewGuid(),
                    MatchContent = matchContent,
                    MatchLevel = maxMatchLevel + 1,
                    MatchOption = matchOption,
                    WechatAccount = wechatAccount
                });

                if (entities.SaveChanges() > 0)
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "add new wechat text request match success!"
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
                        success = false,
                        info = "add new wechat text request match failed!"
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