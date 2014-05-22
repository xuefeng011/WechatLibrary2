using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using WechatLibrary.Converter;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Request.Event;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool DeserializeXDocumentByMessageType()
        {
            Wechat.FireDeserializeXDocumentByMessageTypeStart(this);

            var message = XDocumentRequestMessageConverter.Deserialize(this.RequestXDocument, this.RequestMessageType);
            if (message == null)
            {
                return false;
            }
            else
            {
                this.RequestMessage = message;
            }

            Wechat.FireDeserializeXDocumentByMessageTypeEnd(this);
            return true;
        }
    }
}
