using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service
{
    /// <summary>
    /// 上传下载多媒体文件。
    /// </summary>
    public partial class WechatResourceService
    {
        private const string UploadUrlTemplate = @"http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";

        private const string DownloadUrlTemplate = @"http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";

        /// <summary>
        /// 上传多媒体文件。
        /// </summary>
        /// <param name="wechatResource">多媒体文件</param>
        /// <returns>上传的返回。</returns>
        /// <exception cref="System.ArgumentNullException"><c>wechatResource</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>wechatResource</c> 的值非法。</exception>
        internal static UploadReturn Upload(WechatResource wechatResource)
        {
            if (wechatResource == null)
            {
                throw new ArgumentNullException("wechatResource");
            }
            if (wechatResource.Owner == null)
            {
                throw new ArgumentException("该微信资源没有绑定微信帐号", "wechatResource");
            }
            string type = wechatResource.Type;
            switch (type)
            {
                case "image":
                case "voice":
                case "video":
                case "thumb":
                    {
                        using (var entities=new WechatEntities())
                        {
                            var wechatAccount =
                                entities.WechatAccounts.FirstOrDefault(temp => temp.Id == wechatResource.OwnerWechatAccountId);
                            if (wechatAccount!=null)
                            {
                                wechatResource.Owner = wechatAccount;
                                entities.SaveChanges();
                            }
                        }

                        string url = string.Format(UploadUrlTemplate, wechatResource.Owner.AccessToken.Value, type);
                        byte[] responseBytes;
                        using (var wc = new WebClient())
                        {
                            // 添加 Http 头。
                            wc.Headers.Add("fileName", wechatResource.Id.ToString() + Path.GetExtension(wechatResource.Name));
                            wc.Headers.Add("filelength", wechatResource.Bytes.Length.ToString());
                            wc.Headers.Add("content-type", "application/x-www-form-urlencoded");

                            // 上传数据。
                            responseBytes = wc.UploadData(url, wechatResource.Bytes);
                        }
                        var json = Encoding.Default.GetString(responseBytes);
                        return JsonHelper.Deserialize<UploadReturn>(json);
                    }
                default:
                    {
                        throw new ArgumentException("wechatResource 的类型非法！", "wechatResource");
                    }
            }
        }

        /// <summary>
        /// 下载多媒体文件。
        /// </summary>
        /// <param name="wechatAccount">微信帐号。</param>
        /// <param name="mediaId">多媒体文件的 MediaId。</param>
        /// <returns>成功则返回多媒体文件的字节数组，否则返回空长度的字节数组。</returns>
        public static byte[] Download(WechatAccount wechatAccount, string mediaId)
        {
            if (wechatAccount == null)
            {
                throw new ArgumentNullException("wechatAccount");
            }
            if (mediaId == null)
            {
                throw new ArgumentNullException("mediaId");
            }

            var accessToken = wechatAccount.AccessToken;
            if (accessToken == null)
            {
                wechatAccount.AccessToken = new AccessToken()
                {
                    Id = Guid.NewGuid(),
                    WechatAccount = wechatAccount
                };
            }
            string url = string.Format(DownloadUrlTemplate, wechatAccount.AccessToken.Value, mediaId);
            WebClient wc = new WebClient();
            var bytes = wc.DownloadData(url);
            // check is error
            try
            {
                string json = Encoding.UTF8.GetString(bytes);
                try
                {
                    ReturnBase returnBase = JsonHelper.Deserialize<ReturnBase>(json);
                    if (returnBase.ErrorCode != 0)
                    {
                        bytes = new byte[0];
                    }
                }
                catch (JsonDeserializeException)
                {
                }
            }
            catch
            {
            }
            return bytes;
        }
    }
}
