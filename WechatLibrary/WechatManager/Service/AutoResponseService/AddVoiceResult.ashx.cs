using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Service;

namespace WechatManager.Service.AutoResponseService
{
    /// <summary>
    /// AddVoiceResult 的摘要说明
    /// </summary>
    public class AddVoiceResult : IHttpHandler, IRequiresSessionState
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

            if (context.Request.Files.Count != 1)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select a voice to upload!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

            HttpPostedFile file = context.Request.Files[0];
            var fileName = file.FileName;
            var bytesCount = file.ContentLength;
            var bytes = new byte[bytesCount];
            file.InputStream.Read(bytes, 0, bytesCount);

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

                // Get current user.
                var wechatAccount = query.First();

                var voiceAutoResponseResult = new VoiceAutoResponseResult();

                var wechatResource = new WechatResource();

                wechatResource.Id = Guid.NewGuid();
                wechatResource.Bytes = bytes;
                wechatResource.Name = fileName;
                wechatResource.Owner = wechatAccount;
                wechatResource.OwnerWechatAccountId = wechatAccount.Id;
                wechatResource.Type = "voice";

                voiceAutoResponseResult.Id = Guid.NewGuid();
                voiceAutoResponseResult.WechatResource = wechatResource;

                wechatAccount.VoiceAutoResponseResults.Add(voiceAutoResponseResult);

                entities.SaveChanges();
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "add success"
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