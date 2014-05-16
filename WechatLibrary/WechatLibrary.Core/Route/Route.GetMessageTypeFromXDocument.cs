using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.Route
{
    public partial class Route
    {
        public void GetMessageTypeFromXDocument()
        {
            var root = this.RequestXDocument.Root;
            var msgType = root.Element("MsgType");
            var msgTypeValue = msgType.Value.ToLower();
            switch (msgTypeValue)
            {
                case "text":
                case "image":
                case "voice":
                case "video":
                case "location":
                case "link":
                    {
                        this.RequestMessageType = msgTypeValue;
                        break;
                    }
                case "event":
                    {
                        var eventType = root.Element("Event");
                        var eventTypeValue = eventType.Value.ToLower();
                        switch (eventTypeValue)
                        {
                            case "subscribe":
                                {
                                    var eventKey = root.Element("EventKey");
                                    if (eventKey == null || string.IsNullOrEmpty(eventKey.Value) == true)
                                    {
                                        this.RequestMessageType = "subscribe";
                                    }
                                    else
                                    {
                                        this.RequestMessageType = "qrsubscribe";
                                    }
                                    break;
                                }
                            case "unsubscribe":
                                {
                                    this.RequestMessageType = "unsubscribe";
                                    break;
                                }
                            case "scan":
                                {
                                    this.RequestMessageType = "scan";
                                    break;
                                }
                            case "location":
                                {
                                    this.RequestMessageType = "location";
                                    break;
                                }
                            case "click":
                                {
                                    this.RequestMessageType = "click";
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
    }
}
