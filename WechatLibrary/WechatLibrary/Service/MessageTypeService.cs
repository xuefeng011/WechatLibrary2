using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WechatLibrary.Model.Message.Request;

namespace WechatLibrary.Service
{
    public partial class MessageTypeService
    {
        public static RequestMessageType GetMessageTypeFromXDocument(XDocument document)
        {
            var root = document.Root;
            if (root == null)
            {
                return RequestMessageType.Unknown;
            }
            var msgTypeElement = root.Element("MsgType");
            if (msgTypeElement == null)
            {
                return RequestMessageType.Unknown;
            }
            var msgTypeValue = msgTypeElement.Value.ToLower();
            switch (msgTypeValue)
            {
                case "text":
                    {
                        return RequestMessageType.Text;
                    }
                case "image":
                    {
                        return RequestMessageType.Image;
                    }
                case "voice":
                    {
                        return RequestMessageType.Voice;
                    }
                case "video":
                    {
                        return RequestMessageType.Video;
                    }
                case "location":
                    {
                        return RequestMessageType.Location;
                    }
                case "link":
                    {
                        return RequestMessageType.Link;
                    }
                case "event":
                    {
                        var eventTypeElement = root.Element("Event");
                        if (eventTypeElement == null)
                        {
                            return RequestMessageType.Unknown;
                        }
                        var eventTypeValue = eventTypeElement.Value.ToLower();
                        switch (eventTypeValue)
                        {
                            case "subscribe":
                                {
                                    var eventKeyElement = root.Element("EventKey");
                                    if (eventKeyElement == null || string.IsNullOrEmpty(eventKeyElement.Value) == true)
                                    {
                                        return RequestMessageType.Subscribe;
                                    }
                                    else
                                    {
                                        return RequestMessageType.QRSubscribe;
                                    }
                                }
                            case "unsubscribe":
                                {
                                    return RequestMessageType.Unsubscribe;
                                }
                            case "scan":
                                {
                                    return RequestMessageType.QRScan;
                                }
                            case "location":
                                {
                                    return RequestMessageType.UploadLocation;
                                    }
                            case "click":
                                {
                                    return RequestMessageType.MenuButtonClick;
                                }
                            case "view":
                                {
                                    return RequestMessageType.MenuButtonView;
                                }
                            default:
                                {
                                    return RequestMessageType.Unknown;
                                }
                        }
                    }
                default:
                    {
                        return RequestMessageType.Unknown;
                    }
            }
        }
    }
}
