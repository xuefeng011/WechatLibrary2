﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WechatLibrary.Interface.Handler;
using WechatLibrary.Model.Message.Response;
using WechatLibrary.Service;
using EmptyResult = System.Web.Mvc.EmptyResult;

namespace WechatManager.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["WechatId"] != null)
            {
                return Redirect("/Desktop/Index");
            }
            return View();
        }

        public ActionResult AddWechatAccount()
        {
            return View();
        }

#if DEBUG
        public ActionResult Test()
        {
            WechatLibrary.Wechat.ProcessRequest();
            return new EmptyResult();
        }
#endif
    }

}

#if DEBUG
namespace HZFTest
{
    public class TextHandler : ITextHandler
    {
        public WechatLibrary.Model.Message.Response.ResponseResultBase ProcessRequest(WechatLibrary.Model.Message.Request.Normal.TextMessage message, ref bool dbProcess)
        {
            var newsResult = new NewsResult();
            newsResult.Articles.Add(new NewsArticle()
            {
                Title = "title",
                Description = "description",
                PicUrl = "http://www.baidu.com/img/bdlogo.gif",
                Url = "www.baidu.com"
            });
            return newsResult;

            var pre = MessageLogService.GetPrevTextMessage(message);
            if (pre != null)
            {
                return new TextResult()
                {
                    Content = "prev is " + pre.Content
                };
            }
            else
            {
                return new TextResult()
                {
                    Content = "prev is empty"
                };
            }
        }
    }
}
#endif