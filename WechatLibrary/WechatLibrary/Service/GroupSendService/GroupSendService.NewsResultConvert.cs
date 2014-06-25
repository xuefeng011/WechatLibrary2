using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Model.GroupSend;

namespace WechatLibrary.Service.GroupSendService
{
    public partial class GroupSendService
    {
        public static GroupSendNews ToGroupSend(NewsAutoResponseResult newsResult, List<string> userList, WechatAccount wechatAccount)
        {
            var groupSend = new GroupSendNews();
            for (int i = 0; i < newsResult.NewsAutoResponseArticles.Count; i++)
            {
                try
                {
                    WebClient wc = new WebClient();
                    // download image data.
                    var bytes = wc.DownloadData(newsResult.NewsAutoResponseArticles[i].PicUrl);
                    wc.Dispose();

                    // upload resource to wechat server to get media id.
                    var uploadReturn = WechatResourceService.Upload(new WechatResource()
                           {
                               Bytes = bytes,
                               ExpiresTime = new DateTime(1970, 1, 1),
                               Id = Guid.NewGuid(),
                               Name = Path.GetFileName(newsResult.NewsAutoResponseArticles[i].PicUrl),
                               Owner = wechatAccount,
                               OwnerWechatAccountId = wechatAccount.Id,
                               RefreshTime = new DateTime(1970, 1, 1),
                               Type = "image"
                           });

                    groupSend.Articles.Add(new GroupSendNewsArticles()
                    {
                        Content = newsResult.NewsAutoResponseArticles[i].Description,
                        ContentSourceUrl = newsResult.NewsAutoResponseArticles[i].Url,
                        Title = newsResult.NewsAutoResponseArticles[i].Title,
                        ThumbMediaId = uploadReturn.MediaId
                    });
                }
                catch
                {
                    continue;
                }
            }
            return groupSend;
        }
    }
}
