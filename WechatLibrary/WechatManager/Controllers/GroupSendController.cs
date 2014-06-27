using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WechatLibrary.Model;

namespace WechatManager.Controllers
{
    public class GroupSendController : Controller
    {
        public ActionResult Index()
        {
            var wechatId = Session["WechatId"] as string;
            using (var entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.WechatId == wechatId);
                var wechatAccount = query.FirstOrDefault();
                if (wechatAccount == null)
                {
                    return Content("<html><head></head><body><h1>请重新登录</h1></body></html>", "text/html");
                }
                if (wechatAccount.IsServerAccount == false)
                {
                    return Content("<html><head></head><body><h1>订阅号无法使用此功能</h1></body></html>", "text/html");
                }
            }

            return View();
        }
    }
}
