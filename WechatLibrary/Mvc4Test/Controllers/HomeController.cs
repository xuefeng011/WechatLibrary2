using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WechatLibrary.Model;

namespace Mvc4Test.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            using (WechatLibrary.Model.WechatEntities context = new WechatLibrary.Model.WechatEntities())
            {
                if (context.WechatAccounts.Count() <= 0)
                {
                    context.WechatAccounts.Add(new WechatAccount()
                    {
                        Id = Guid.NewGuid(),
                        AppId = "123",
                        Secret = "456",
                        Token = "789",
                        Namespace = "Mvc4Test",
                        WechatId = "toUser"
                    });
                    context.SaveChanges();
                }
            }

            WechatLibrary.Core.Wechat.ProcessRequest();
            return new EmptyResult();
        }
    }
}
