﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Serialization.Json;
using Ext.Net;
using WechatLibrary.Model;

namespace WechatManager.Service.AutoResponseService
{
    /// <summary>
    /// DeleteVoiceResult 的摘要说明
    /// </summary>
    public class DeleteVoiceResult : IHttpHandler, IRequiresSessionState
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

            var deleteId = context.Request["Id"];
            if (string.IsNullOrEmpty(deleteId) == true)
            {
                var responseObj = new
                {
                    success = false,
                    info = "please select an item to delete!"
                };
                var json = JsonHelper.SerializeToJson(responseObj);
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                return;
            }

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
                        info = "data base occurred an error! please contact the manager!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                var wechatAccount = query.First();
                var deleteItemQuery = wechatAccount.VoiceAutoResponseResults.Where(temp => temp.Id.ToString() == deleteId);
                if (deleteItemQuery.Count() != 1)
                {
                    var responseObj = new
                    {
                        success = false,
                        info = "this item is not exist in the data base!"
                    };
                    var json = JsonHelper.SerializeToJson(responseObj);
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    return;
                }

                wechatAccount.VoiceAutoResponseResults.Remove(deleteItemQuery.First());
                entities.SaveChanges();
                {
                    var responseObj = new
                    {
                        success = true,
                        info = "delete success!"
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