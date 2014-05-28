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
    public class WechatServerMenuController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}
