using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using WechatLibrary.Model;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service
{
    /// <summary>
    /// 上传下载多媒体文件。
    /// </summary>
    public partial class MediaFileService
    {

        private const string DownloadUrlTemplate = @"http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";

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
