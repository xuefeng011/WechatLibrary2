using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Service;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 从消息 XDocument 中获取消息类型。
        /// </summary>
        /// <returns></returns>
        public bool GetMessageTypeFromXDocument()
        {
            Wechat.FireGetMessageTypeFromXDocumentStart(this);

            var messageType = MessageTypeService.GetMessageTypeFromXDocument(this.RequestXDocument);
            if (messageType == RequestMessageType.Unknown)
            {
                return false;
            }
            else
            {
                this.RequestMessageType = messageType;
            }

            Wechat.FireGetMessageTypeFromXDocumentEnd(this);
            return true;
        }
    }
}
