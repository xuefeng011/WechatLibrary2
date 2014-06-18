using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.SessionState;
using System.Xml.Linq;
using WechatLibrary;
using WechatLibrary.Model;

namespace WechatManager.Service.MessageLogService
{
    /// <summary>
    /// GetResponseResultSource 的摘要说明
    /// </summary>
    public class GetResponseResultSource : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var wechatId = context.Session["WechatId"] as string;
            if (string.IsNullOrEmpty(wechatId) == true)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("please login again!");
                return;
            }

            using (var entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.WechatId == wechatId);
                if (query.Count() < 1)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("please login again!");
                    return;
                }
                if (query.Count() > 1)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("data base occurred an error, please contact the manager!");
                    return;
                }

                // Get current user.
                var wechatAccount = query.First();

                var requestMessageId = context.Request["Id"];

                var query2 = wechatAccount.ReceiveLogs.Where(temp => temp.Id.ToString() == requestMessageId);
                if (query2.Count() < 1)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("this message had been removed");
                    return;
                }
                if (query2.Count() > 1)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("data base occurred an error! please contact the manager and tell him/her there are two or more request message logs have the same id.");
                    return;
                }

                {
                    var result = query2.Single().Result;

                    if (result == null || string.IsNullOrEmpty(result.XmlSource) == true)
                    {
                        context.Response.ContentType = "text/html";
                        context.Response.Write("<html><head></head><body></body></html>");
                        return;
                    }

                    var responseXml = result.XmlSource;
                    // Just for format the xml.
                    var responseXDocument = XDocument.Parse(responseXml);
                    responseXml = responseXDocument.ToString();
                    var responseHtml = "<html><head></head><body>" + responseXml.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\r", "<br/>").Replace(" ", "&nbsp;") + "</body></html>";
                    context.Response.ContentType = "text/html";
                    context.Response.Write(responseHtml);
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