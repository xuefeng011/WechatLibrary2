using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Serialization.Json;
using Ext.Net;
using WechatLibrary.Model;

namespace WechatManager.Service.WechatAccountService
{
    /// <summary>
    /// AddNewWechatAccount 的摘要说明
    /// </summary>
    public class AddNewWechatAccount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // get parameters.
            var request = context.Request;
            var appId = request["AppId"] ?? string.Empty;
            var secret = request["Secret"] ?? string.Empty;
            var token = request["Token"] ?? string.Empty;
            var wechatId = request["WechatId"] ?? string.Empty;
            var @namespace = request["Namespace"] ?? string.Empty;
            // 是否服务号。
            bool isServerAccount = request["IsServerAccount"] == "serverAccount";

            // set response type.
            context.Response.ContentType = "text/json";

            // check parameters exist null or empty string.
            if (string.IsNullOrEmpty(appId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "AppId 不能为空！"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.Write(json);
                return;
            }
            if (string.IsNullOrEmpty(secret) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "Secret 不能为空！"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.Write(json);
                return;
            }
            if (string.IsNullOrEmpty(token) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "Token 不能为空！"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.Write(json);
                return;
            }
            if (string.IsNullOrEmpty(wechatId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "WechatId 不能为空！"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.Write(json);
                return;
            }

            using (var entities = new WechatEntities())
            {
                int count = 0;

                // check parameters from data base.
                count = entities.WechatAccounts.Count(temp => temp.WechatId == wechatId);
                if (count > 0)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "WechatId 不能有一个以上！"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.Write(json);
                    return;
                }

                var wechatAccount = new WechatAccount()
                {
                    Id = Guid.NewGuid(),
                    AppId = appId,
                    Secret = secret,
                    Token = token,
                    WechatId = wechatId,
                    Namespace = @namespace,
                    IsServerAccount = isServerAccount
                };

                wechatAccount.AccessToken = new AccessToken()
                {
                    Id = Guid.NewGuid(),
                    WechatAccount = wechatAccount,
                    ExpiresTime = new DateTime(1970, 1, 1)
                };

                // add entity.
                entities.WechatAccounts.Add(wechatAccount);
                entities.AccessTokens.Add(wechatAccount.AccessToken);

                // try save change.
                if (entities.SaveChanges() > 0)
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "添加成功！"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.Write(json);
                    return;
                }
                else
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "添加失败！"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
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