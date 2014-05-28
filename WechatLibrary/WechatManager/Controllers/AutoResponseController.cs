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
    public class AutoResponseController : Controller
    {
        //
        // GET: /Home/

        public ActionResult ResponseResultManage()
        {
            return View();
        }
    }
}
