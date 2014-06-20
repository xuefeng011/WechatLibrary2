using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Result;

namespace WechatManager.Service.AutoResponseService
{
    /// <summary>
    /// AddImageResult 的摘要说明
    /// </summary>
    public class AddImageResult : IHttpHandler, IRequiresSessionState
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

            //var mediaId = context.Request["MediaId"];
            //if (string.IsNullOrEmpty(mediaId) == true)
            //{
            //    var responseObj = new
            //    {
            //        success = false,
            //        info = "please input media id!"
            //    };
            //    var json = JsonHelper.SerializeToJson(responseObj);
            //    context.Response.ContentType = "text/json";
            //    context.Response.Write(json);
            //    return;
            //}

            //var imgUrl = context.Request["ImgUrl"];
            //if (string.IsNullOrEmpty(imgUrl) == true)
            //{
            //    var responseObj = new
            //    {
            //        success = false,
            //        info = "please input image url!"
            //    };
            //    var json = JsonHelper.SerializeToJson(responseObj);
            //    context.Response.ContentType = "text/json";
            //    context.Response.Write(json);
            //    return;
            //}

            if (context.Request.Files.Count != 1)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select an image to upload!"
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
                        info = "data base occurred an error!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                // Get current user.
                var wechatAccount = query.First();

                var imageAutoResponseResult = new ImageAutoResponseResult();

                var wechatResource = new WechatResource();

                wechatAccount.ImageAutoResponseResults.Add(imageAutoResponseResult);

                wechatResource.Id = Guid.NewGuid();
                wechatResource.Bytes = bytes;
                wechatResource.Name = fileName;
                wechatResource.Owner = wechatAccount;
                wechatResource.OwnerWechatAccountId = wechatAccount.Id;
                wechatResource.Type = "image";
                wechatResource.ExpiresTime = new DateTime(1970, 1, 1);
                wechatResource.RefreshTime = new DateTime(1970, 1, 1);

                imageAutoResponseResult.Id = Guid.NewGuid();
                imageAutoResponseResult.WechatResource = wechatResource;

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