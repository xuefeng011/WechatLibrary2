using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Request.Event;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 根据消息类型从缓存中获取处理类的 ProcessRequest 方法。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool GetHandlerProcessRequestMethodFromCacheByMessageType()
        {
            Wechat.FireGetHandlerProcessRequestMethodFromCacheByMessageTypeStart(this);

            switch (this.RequestMessageType)
            {
                case RequestMessageType.Text:
                    {
                        if (Cache.Cache.TextHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.TextHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Image:
                    {
                        if (Cache.Cache.ImageHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.ImageHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Voice:
                    {
                        if (Cache.Cache.VoiceHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.VoiceHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Video:
                    {
                        if (Cache.Cache.VideoHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.VideoHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Location:
                    {
                        if (Cache.Cache.LocationHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.LocationHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Link:
                    {
                        if (Cache.Cache.LinkHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.LinkHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Subscribe:
                    {
                        if (Cache.Cache.SubscribeHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.SubscribeHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.QRSubscribe:
                    {
                        if (Cache.Cache.QRSubscribeHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.QRSubscribeHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Unsubscribe:
                    {
                        if (Cache.Cache.UnsubscribeHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.UnsubscribeHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.QRScan:
                    {
                        if (Cache.Cache.QRScanHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.QRScanHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.UploadLocation:
                    {
                        if (Cache.Cache.UploadLocationHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.UploadLocationHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.MenuButtonClick:
                    {
                        if (Cache.Cache.MenuButtonClickHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            MenuButtonClickMessage menuButtonClickMessage = this.RequestMessage as MenuButtonClickMessage;
                            if (menuButtonClickMessage == null)
                            {
                                this.DbProcess = true;
                                break;
                            }
                            var key = menuButtonClickMessage.EventKey.ToLower();
                            var tempDictionary = Cache.Cache.MenuButtonClickHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                            if (tempDictionary.ContainsKey(key.ToLower()) == true)
                            {
                                this.HandlerProcessRequestMethod = tempDictionary[key];
                            }
                            else
                            {
                                this.DbProcess = true;
                            }
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.MenuButtonView:
                    {
                        if (Cache.Cache.MenuButtonViewHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.MenuButtonViewHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                default:
                    {
                        this.DbProcess = true;
                        break;
                    }
            }

            Wechat.FireGetHandlerProcessRequestMethodFromCacheByMessageTypeEnd(this);
            return true;
        }
    }
}
