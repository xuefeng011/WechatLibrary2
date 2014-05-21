using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;

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

            var root = this.RequestXDocument.Root;
            if (root == null)
            {
                return false;
            }
            var msgTypeElement = root.Element("MsgType");
            if (msgTypeElement == null)
            {
                return false;
            }
            var msgTypeValue = msgTypeElement.Value.ToLower();
            switch (msgTypeValue)
            {
                case "text":
                    {
                        this.RequestMessageType = Model.Message.Request.RequestMessageType.Text;
                        break;
                    }
                case "image":
                    {
                        this.RequestMessageType = Model.Message.Request.RequestMessageType.Image;
                        break;
                    }
                case "voice":
                    {
                        this.RequestMessageType = Model.Message.Request.RequestMessageType.Voice;
                        break;
                    }
                case "video":
                    {
                        this.RequestMessageType = Model.Message.Request.RequestMessageType.Video;
                        break;
                    }
                case "location":
                    {
                        this.RequestMessageType = Model.Message.Request.RequestMessageType.Location;

                        break;
                    }
                case "link":
                    {
                        this.RequestMessageType = Model.Message.Request.RequestMessageType.Link;
                        break;
                    }
                case "event":
                    {
                        var eventTypeElement = root.Element("Event");
                        if (eventTypeElement == null)
                        {
                            return false;
                        }
                        var eventTypeValue = eventTypeElement.Value.ToLower();
                        switch (eventTypeValue)
                        {
                            case "subscribe":
                                {
                                    var eventKeyElement = root.Element("EventKey");
                                    if (eventKeyElement == null || string.IsNullOrEmpty(eventKeyElement.Value) == true)
                                    {
                                        this.RequestMessageType = Model.Message.Request.RequestMessageType.Subscribe;
                                    }
                                    else
                                    {
                                        this.RequestMessageType = Model.Message.Request.RequestMessageType.QRSubscribe;
                                    }
                                    break;
                                }
                            case "unsubscribe":
                                {
                                    this.RequestMessageType = Model.Message.Request.RequestMessageType.Unsubscribe;
                                    break;
                                }
                            case "scan":
                                {
                                    this.RequestMessageType = Model.Message.Request.RequestMessageType.QRScan;
                                    break;
                                }
                            case "location":
                                {
                                    this.RequestMessageType = Model.Message.Request.RequestMessageType.UploadLocation;
                                    break;
                                }
                            case "click":
                                {
                                    this.RequestMessageType = Model.Message.Request.RequestMessageType.MenuButtonClick;
                                    break;
                                }
                            case "view":
                                {
                                    this.RequestMessageType = Model.Message.Request.RequestMessageType.MenuButtonView;
                                    break;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            Wechat.FireGetMessageTypeFromXDocumentEnd(this);
            return true;
        }
    }
}
