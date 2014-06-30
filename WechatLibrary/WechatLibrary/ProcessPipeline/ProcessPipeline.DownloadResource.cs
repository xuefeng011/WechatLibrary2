using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WechatLibrary.Model;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool DownloadResource()
        {
            try
            {
                using (var entities = new WechatEntities())
                {
                    var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == this.RequestMessage.ToUserName);
                    if (wechatAccount == null)
                    {
                        return true;
                    }

                    ImageMessage imageMessage = this.RequestMessage as ImageMessage;
                    if (imageMessage != null)
                    {
                        var bytes = WechatLibrary.Service.WechatResourceService.Download(wechatAccount, imageMessage.MediaId);
                        var directoryPath = System.Web.HttpContext.Current.Server.MapPath("/userimages");
                        if (Directory.Exists(directoryPath) == false)
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                        var fileName = this.RequestMessage.FromUserName + "_" + DateTime.Now.ToString() + ".jpg";
                        var fullPath = Path.Combine(directoryPath, fileName);
                        File.WriteAllBytes(fullPath, bytes);
                        return true;
                    }
                    VoiceMessage voiceMessage = this.RequestMessage as VoiceMessage;
                    if (voiceMessage != null)
                    {
                        var bytes = WechatLibrary.Service.WechatResourceService.Download(wechatAccount,
                            voiceMessage.MediaId);
                        var directoryPath = System.Web.HttpContext.Current.Server.MapPath("/uservoices");
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                        var fileName = this.RequestMessage.FromUserName + "_" + DateTime.Now.ToString() + ".mp3";
                        var fullPath = Path.Combine(directoryPath, fileName);
                        File.WriteAllBytes(fullPath, bytes);
                        return true;
                    }
                    return true;
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
