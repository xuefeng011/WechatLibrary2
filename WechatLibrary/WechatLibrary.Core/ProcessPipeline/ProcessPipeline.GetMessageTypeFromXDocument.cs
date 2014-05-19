using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 从消息 XDocument 中获取消息类型。
        /// </summary>
        public void GetMessageTypeFromXDocument()
        {
            var root = this.RequestXDocument.Root;
            if (root == null)
            {
                return;
            }
            var msgType = root.Element("MsgType");
            if (msgType == null)
            {
                return;
            }
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
                                    this.RequestMessageType = "uploadlocation";
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
