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
                if (images.Count() != 1)
                {
                    return Content("image id error!");
                }
                var image = images.First();
                return File(image.WechatResource.Bytes, "image/jpeg");
            }
        }

        public ActionResult DownloadVoice(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Content("voice id is null!");
            }

            using (var entities = new WechatEntities())
            {
                var voices = entities.VoiceAutoResponseResults.Where(temp => temp.Id.ToString() == id);
                if (voices.Count() != 1)
                {
                    return Content("voice id error!");
                }
                var voice = voices.First();
                return File(voice.WechatResource.Bytes, "application/octet-stream", voice.WechatResource.Name);
            }
        }
    }
}
