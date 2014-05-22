using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Converter;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 执行数据库图片消息的自动回复。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool ExecuteImageMessageDataBaseProcess()
        {
            var imageMessage = this.RequestMessage as ImageMessage;
            if (imageMessage == null)
            {
                return false;
            }
            using (WechatEntities entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == this.RequestMessage.ToUserName);
                if (wechatAccount == null)
                {
                    return false;
                }
                var imageMessageMatch = wechatAccount.ImageMessageMatch;
                if (imageMessageMatch == null)
                {
                    return false;
                }
                this.ResponseResult =
                    AutoResponseResultConverter.ConvertTo(MatchResultMapping.GetMapping(imageMessageMatch));
            }
            return false;
        }
    }
}
