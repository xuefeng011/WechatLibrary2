using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using WechatLibrary;
using WechatLibrary.Model;

namespace WechatManager.Controllers
{
    public class DesktopController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["WechatId"] == null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        public ActionResult Login(string wechatId)
        {
            if (string.IsNullOrEmpty(wechatId) == true)
            {
                return Json(new
                {
                    success = false,
                    info = "wechatId is null or empty string."
                });
            }

            using (var entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.WechatId == wechatId);
                if (query.Count() <= 0)
                {
                    return Json(new
                    {
                        success = false,
                        info = "wechatId: " + wechatId + " is not exist in the data base."
                    });
                }
                if (query.Count() > 1)
                {
                    return Json(new
                    {
                        success = false,
                        info = "there is something wrong in the data base, please contact the manager."
                    });
                }

                var wechatAccount = query.First();

                // save wechatId to session.
                Session.Timeout = 60 * 24;
                Session["WechatId"] = wechatAccount.WechatId;

                return Json(new
                {
                    success = true,
                    info = "login success!"
                });
            }
        }

        public ActionResult Logout()
        {
            // clear the login user session.
            Session.RemoveAll();
            // navigate to /home/index.
            return Redirect("/Home/Index");
        }
    }
}
