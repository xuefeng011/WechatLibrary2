using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Ext.Net.Utilities;
using WechatLibrary.Model;

namespace WechatManager.Service.GroupSendService
{
    /// <summary>
    /// SendImage 的摘要说明
    /// </summary>
    public class SendImage : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var wechatId = context.Session["WechatId"] as string;
            if (wechatId.IsNullOrEmpty())
            {
                context.Response.WriteJson(new
                {
                    success = false,
                    info = "please login again!"
                });
                return;
            }

            var id = context.Request["Id"];
            if (id.IsNullOrEmpty())
            {
                context.Response.WriteJson(new
                {
                    success = false,
                    info = "please select an image to send"
                });
                return;
            }

            using (var entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
                if (wechatAccount == null)
                {
                    context.Response.WriteJson(new
                    {
                        success = false,
                        info = "please login again!"
                    });
                    return;
                }

                var imageResult = wechatAccount.ImageAutoResponseResults.FirstOrDefault(temp => temp.Id.ToString() == id);

                if (imageResult == null)
                {
                    context.Response.WriteJson(new
                    {
                        success = false,
                        info = "image result not exist"
                    });
                    return;
                }

                var success = WechatLibrary.Service.GroupSendService.GroupSendService.Send(imageResult, wechatId);
                {
                    context.Response.WriteJson(new
                    {
                        success = success,
                        info = success ? "send success" : "send fail"
                    });
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