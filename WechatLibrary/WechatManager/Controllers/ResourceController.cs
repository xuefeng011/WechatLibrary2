using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WechatLibrary.Interface.Handler;
using WechatLibrary.Model;
using WechatLibrary.Model.Message.Response;
using WechatLibrary.Service;
using EmptyResult = System.Web.Mvc.EmptyResult;

namespace WechatManager.Controllers
{
    public class ResourceController : Controller
    {
        public ActionResult ViewImage(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Content("image id is null!");
            }

            using (var entities = new WechatEntities())
            {
                var images = entities.ImageAutoResponseResults.Where(temp => temp.Id.ToString() == id);
                if (images.Count()!=1)
                {
                    return Content("image id error!");
                }
                var image = images.First();
                return File(image.WechatResource.Bytes, "image/jpeg");
            }
        }
    }
}
