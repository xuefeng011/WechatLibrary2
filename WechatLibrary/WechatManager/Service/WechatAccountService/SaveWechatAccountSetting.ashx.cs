using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using Ext.Net;
using WechatLibrary.Model;

namespace WechatManager.Service.WechatAccountService
{
    /// <summary>
    /// SaveWechatAccountSetting 的摘要说明
    /// </summary>
    public class SaveWechatAccountSetting : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var currentWechatId = context.Session["WechatId"] as string;
            if (string.IsNullOrEmpty(currentWechatId) == true)
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

            var request = context.Request;
            var appId = request["AppId"] ?? string.Empty;
            var secret = request["Secret"] ?? string.Empty;
            var token = request["Token"] ?? string.Empty;
            var newWechatId = request["WechatId"] ?? string.Empty;
            var @namespace = request["Namespace"] ?? string.Empty;
            var type = request["Type"] == "serverAccount";

            if (string.IsNullOrEmpty(appId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "AppId could not be null or empty!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            if (string.IsNullOrEmpty(secret) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "Secret could not be null or empty!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            if (string.IsNullOrEmpty(token) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "Token could not be null or empty!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            if (string.IsNullOrEmpty(newWechatId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "WechatId could not be null or empty!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            using (var entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.WechatId == currentWechatId);
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
                        info = "there is something wrong in the data base, please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }
                var currentWechatAccount = query.First();
                currentWechatAccount.AppId = appId;
                currentWechatAccount.Secret = secret;
                currentWechatAccount.Token = token;
                currentWechatAccount.WechatId = newWechatId;
                currentWechatAccount.Namespace = @namespace;
                currentWechatAccount.IsServerAccount = type;

                entities.SaveChanges();
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "modify the WechatAccount success!"
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