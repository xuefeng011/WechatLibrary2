using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Result;

namespace WechatLibrary.Service
{
    /// <summary>
    /// 客服消息服务。
    /// </summary>
    public class CustomerServiceMessageService
    {
        /// <summary>
        /// 将文本回复转换到客服消息。
        /// </summary>
        /// <param name="textResult">文本回复。</param>
        /// <param name="toUserName">接收方（即用户）的OpenId。</param>
        /// <returns>Json</returns>
        public static string ConvertToJson(TextAutoResponseResult textResult, string toUserName)
        {
            string json = "{\"touser\":\"" + toUserName + "\",\"msgtype\":\"text\",\"text\":{\"content\":\"" + textResult.Content + "\"}}";
            return json;
        }

        /// <summary>
        /// 将图片回复转换到客服消息。
        /// </summary>
        /// <param name="imageResult">图片回复。</param>
        /// <param name="toUserName">接收方（即用户）的OpenId。</param>
        /// <returns>Json</returns>
        public static string ConvertToJson(ImageAutoResponseResult imageResult, string toUserName)
        {
            string json = "{\"touser\":\"" + toUserName + "\",\"msgtype\":\"image\",\"image\":{\"media_id\":\"" + (imageResult.WechatResource == null ? string.Empty : imageResult.WechatResource.MediaId) + "\"}}";
            return json;
        }

        /// <summary>
        /// 将语音回复转换到客服消息。
        /// </summary>
        /// <param name="voicerResult">语音回复。</param>
        /// <param name="toUserName">接收方（即用户）的OpenId。</param>
        /// <returns>Json</returns>
        public static string ConvertToJson(VoiceAutoResponseResult voicerResult, string toUserName)
        {
            string json = "{\"touser\":\"" + toUserName + "\",\"msgtype\":\"voice\",\"voice\":{\"media_id\":\"" + (voicerResult.WechatResource == null ? string.Empty : voicerResult.WechatResource.MediaId) + "\"}}";
            return json;
        }

        /// <summary>
        /// 将图文回复转换到客服消息。
        /// </summary>
        /// <param name="newsResult">图文消息。</param>
        /// <param name="toUserName">接收方（即用户）的OpenId。</param>
        /// <returns>Json</returns>
        public static string ConvertToJson(NewsAutoResponseResult newsResult, string toUserName)
        {
            /*
            {
    "touser":"OPENID",
    "msgtype":"news",
    "news":{
        "articles": [
         {
             "title":"Happy Day",
             "description":"Is Really A Happy Day",
             "url":"URL",
             "picurl":"PIC_URL"
         },
         {
             "title":"Happy Day",
             "description":"Is Really A Happy Day",
             "url":"URL",
             "picurl":"PIC_URL"
         }
         ]
    }
}*/
            string articles = string.Empty;
            if (newsResult.NewsAutoResponseArticles != null)
            {
                var s = from temp in newsResult.NewsAutoResponseArticles
                        select new
                        {
                            title = temp.Title,
                            description = temp.Description,
                            url = temp.Url,
                            picurl = temp.PicUrl
                        };
                articles = JsonHelper.SerializeToJson(s.ToList());
            }

            var result = new
            {
                touser = toUserName,
                msgtype = "news",
                news = articles
            };

            return JsonHelper.SerializeToJson(result);
        }

        /// <summary>
        /// 发送客服消息。
        /// </summary>
        /// <param name="wechatAccount">发送方帐号。</param>
        /// <param name="json">客服消息。</param>
        /// <returns>是否成功发送。</returns>
        public static bool Send(WechatAccount wechatAccount, string json)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException("json");
            }
            if (wechatAccount.AccessToken == null)
            {
                throw new ArgumentException("accesstoken 为 null。", "wechatAccount");
            }

            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";
            url = string.Format(url, wechatAccount.AccessToken.Value);

            try
            {
                var result = HttpPost(url, json);
                if (result.Contains("\"errcode\":0"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Notice:
        // This method is copyed from https://github.com/JamesYing/JCWX/blob/9b48369ea21a06632b4e11e02c04c7a5fca8b892/Business/Common/HttpHelper.cs
        // I don't know if it works successfuly.
        private static string HttpPost(string url, string content)
        {
            HttpWebRequest req = HttpWebRequest.Create(url)
                     as HttpWebRequest;

            if (req == null)
                throw new ArgumentException();
            var postdate = content;
            var postBytes = Encoding.UTF8.GetBytes(postdate);
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            req.ContentLength = postBytes.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(postBytes, 0, postBytes.Length);
            stream.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode != HttpStatusCode.OK)
                throw new WebException("code" + res.StatusCode);


            using (var rstream = res.GetResponseStream())
            using (var reader = new System.IO.StreamReader(rstream, Encoding.UTF8))
            {
                var result = reader.ReadToEnd();
                reader.Close();
                rstream.Close();

                //res.Close();
                return result;
            }
        }
    }
}
