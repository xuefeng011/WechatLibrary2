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
    /// GetUserInfo 的摘要说明
    /// </summary>
    public class GetUserInfo : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var wechatId = context.Session["WechatId"] as string;
            if (string.IsNullOrEmpty(wechatId))
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

            var openid = context.Request["openid"];
            if (string.IsNullOrEmpty(openid))
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select a user!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            using (var entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
                if (wechatAccount == null)
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

                if (wechatAccount.IsServerAccount == false)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "订阅号没法使用该功能！"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                var userInfo = wechatAccount.UserInfos.FirstOrDefault(temp => temp.OpenId == openid);
                if (userInfo == null)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "user not exist!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                context.Response.Redirect("/MessageLog/RenderUserInfo?userinfo=" + userInfo);
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