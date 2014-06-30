using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Result;

namespace WechatManager.Service.MessageLogService
{
    /// <summary>
    /// SendImageCustom 的摘要说明
    /// </summary>
    public class SendImageCustom : IHttpHandler, IRequiresSessionState
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

            var toUserName = context.Request["ToUserName"];

            if (string.IsNullOrEmpty(toUserName))
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select a user to send."
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            var file = context.Request.Files["fileResponseImageMessage"];

            if (file == null || file.ContentLength == 0)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select an image."
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            byte[] bytes = new byte[file.ContentLength];
            file.InputStream.Read(bytes, 0, bytes.Length);

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
                var sendJson = WechatLibrary.Service.CustomerServiceMessageService.ConvertToJson(new ImageAutoResponseResult()
                {
                    Id = Guid.NewGuid(),
                    WechatResource = new WechatResource()
                    {
                        Bytes = bytes,
                        ExpiresTime = new DateTime(1970, 1, 1),
                        Id = Guid.NewGuid(),
                        Name = file.FileName,
                        Owner = wechatAccount,
                        OwnerWechatAccountId = wechatAccount.Id,
                        RefreshTime = new DateTime(1970, 1, 1),
                        Type = "image"
                    }
                }, toUserName);
                var success = WechatLibrary.Service.CustomerServiceMessageService.Send(wechatAccount, sendJson);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}