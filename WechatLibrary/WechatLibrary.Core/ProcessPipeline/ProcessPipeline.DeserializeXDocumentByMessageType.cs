using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Request.Event;
using WechatLibrary.Service.Converter;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public void DeserializeXDocumentByMessageType()
        {
            switch (this.RequestMessageType)
            {
                case "text":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<TextMessage>(this.RequestXDocument);
                        break;
                    }
                case "image":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<ImageMessage>(this.RequestXDocument);
                        break;
                    }
                case "voice":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<VoiceMessage>(this.RequestXDocument);
                        break;
                    }
                case "video":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<VideoMessage>(this.RequestXDocument);
                        break;
                    }
                case "location":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<LocationMessage>(this.RequestXDocument);
                        break;
                    }
                case "link":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<LinkMessage>(this.RequestXDocument);
                        break;
                    }
                case "subscribe":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<SubscribeMessage>(this.RequestXDocument);
                        break;
                    }
                case "qrsubscribe":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<QRSubscribeMessage>(this.RequestXDocument);
                        break;
                    }
                case "unsubscribe":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<UnsubscribeMessage>(this.RequestXDocument);
                        break;
                    }
                case "scan":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<QRScanMessage>(this.RequestXDocument);
                        break;
                    }
                case "uploadlocation":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<UploadLocationMessage>(this.RequestXDocument);
                        break;
                    }
                case "click":
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<MenuButtonMessage>(this.RequestXDocument);
                        break;
                    }
            }
        }
    }
}
