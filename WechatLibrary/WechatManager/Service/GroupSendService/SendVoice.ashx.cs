using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Ext.Net;
using Microsoft.SqlServer.Server;
using WechatLibrary.Model;

namespace WechatManager.Service.GroupSendService
{
    /// <summary>
    /// SendVoice 的摘要说明
    /// </summary>
    public class SendVoice : IHttpHandler, IRequiresSessionState
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
                    info = "please select an voice to send"
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

                var voiceResult = wechatAccount.VoiceAutoResponseResults.FirstOrDefault(temp => temp.Id.ToString() == id);

                if (voiceResult == null)
                {
                    context.Response.WriteJson(new
                    {
                        success = false,
                        info = "voice result not exist"
                    });
                    return;
                }

                var success = WechatLibrary.Service.GroupSendService.GroupSendService.Send(voiceResult, wechatId);
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