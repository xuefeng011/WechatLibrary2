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

            switch (this.RequestMessageType)
            {
                case RequestMessageType.Text:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<TextMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.Image:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<ImageMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.Voice:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<VoiceMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.Video:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<VideoMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.Location:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<LocationMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.Link:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<LinkMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.Subscribe:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<SubscribeMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.QRSubscribe:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<QRSubscribeMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.Unsubscribe:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<UnsubscribeMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.QRScan:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<QRScanMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.UploadLocation:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<UploadLocationMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.MenuButtonClick:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<MenuButtonClickMessage>(this.RequestXDocument);
                        break;
                    }
                case RequestMessageType.MenuButtonView:
                    {
                        this.RequestMessage = XDocumentRequestMessageConverter.Deserialize<MenuButtonViewMessage>(this.RequestXDocument);
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            Wechat.FireDeserializeXDocumentByMessageTypeEnd(this);
            return true;
        }
    }
}
