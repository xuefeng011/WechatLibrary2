using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Common.Serialization.Json;
using WechatLibrary.Interface.Handler;
using WechatLibrary.Model;
using WechatLibrary.Model.Message.Response;
using WechatLibrary.Model.UserManagement;
using WechatLibrary.Service;

namespace WechatManager.Controllers
{
    public class MessageLogController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderUserInfo(string userinfo)
        {
            var userInfoReturn = JsonHelper.Deserialize<UserInfoReturn>(userinfo);
            ViewBag.UserInfo = userInfoReturn;
            return View();
        }

        public ActionResult RenderRequest(string xml)
        {
            xml = Session["xml"] as string;
            XDocument xDocument = XDocument.Parse(xml);
            var type = xDocument.Root.Element("MsgType").Value;
            switch (type.ToLower())
            {
                case "text":
                    {
                        return Content("文本消息内容：" + xDocument.Root.Element("Content").Value);
                    }
                case "image":
                    {
                        var mediaId = xDocument.Root.Element("MediaId").Value;
                        ViewBag.MediaId = mediaId;
                        return View("Image");
                    }
                case "voice":
                    {
                        var mediaId = xDocument.Root.Element("MediaId").Value;
                        ViewBag.MediaId = mediaId;
                        return View("Voice");
                    }
                default:
                    {
                        return Content(xml);
                    }
            }
        }

        public ActionResult ViewImage(string MediaId)
        {
            using (var entities = new WechatEntities())
            {
                var wechatId = Session["WechatId"] as string;
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
                var bytes = WechatLibrary.Service.WechatResourceService.Download(wechatAccount, Request["MediaId"]);
                return File(bytes, "image/jpeg");
            }
        }

        public ActionResult ViewVoice(string MediaId)
        {
            using (var entities = new WechatEntities())
            {
                var wechatId = Session["WechatId"] as string;
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
                var bytes = WechatLibrary.Service.WechatResourceService.Download(wechatAccount, Request["MediaId"]);
                return File(bytes, "application/octet-stream");
            }
        }

        public ActionResult RenderResponse(string xml)
        {
            xml = Session["xml"] as string;
            XDocument xd = XDocument.Parse(xml);
            var root = xd.Root;
            var type = root.Element("MsgType").Value;
            switch (type.ToLower())
            {
                case "text":
                    {
                        return Content("文本消息内容：" + xd.Root.Element("Content").Value);
                    }
                case "image":
                    {
                        var mediaId = xd.Root.Element("MediaId").Value;
                        ViewBag.MediaId = mediaId;
                        return View("Image");
                    }
                case "voice":
                    {
                        var mediaId = xd.Root.Element("MediaId").Value;
                        ViewBag.MediaId = mediaId;
                        return View("Voice");
                    }
                case "news":
                    {
                        var articles = xd.Root.Element("Articles");
                        var items = articles.Elements("item");
                        var newsResult = new NewsResult();
                        foreach (var xElement in items)
                        {
                            var url = xElement.Element("Url").Value;
                            if (url.StartsWith("http://") == false)
                            {
                                url = "http://" + url;
                            }
                            var picurl = xElement.Element("PicUrl").Value;
                            if (picurl.StartsWith("http://") == false)
                            {
                                picurl = "http://" + picurl;
                            }
                            newsResult.Articles.Add(new NewsArticle()
                            {
                                Title = xElement.Element("Title").Value,
                                Description = xElement.Element("Description").Value,
                                Url = url,
                                PicUrl = picurl
                            });
                        }
                        ViewBag.NewsResult = newsResult;
                        return View("News");
                    }
                default:
                    {
                        return Content(xml);
                    }
            }
        }
    }
}
