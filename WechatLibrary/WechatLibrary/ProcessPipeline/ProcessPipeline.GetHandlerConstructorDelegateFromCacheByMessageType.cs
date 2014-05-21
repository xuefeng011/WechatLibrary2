using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Request.Event;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool GetHandlerConstructorDelegateFromCacheByMessageType()
        {
            Wechat.FireGetHandlerConstructorDelegateFromCacheByMessageTypeStart(this);

            switch (this.RequestMessageType)
            {
                case RequestMessageType.Text:
                    {
                        if (Cache.Cache.TextHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.TextHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Image:
                    {
                        if (Cache.Cache.ImageHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.ImageHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Voice:
                    {
                        if (Cache.Cache.VoiceHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.VoiceHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Video:
                    {
                        if (Cache.Cache.VideoHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.VideoHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Location:
                    {
                        if (Cache.Cache.LocationHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.LocationHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Link:
                    {
                        if (Cache.Cache.LinkHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.LinkHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Subscribe:
                    {
                        if (Cache.Cache.SubscribeHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.SubscribeHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.QRSubscribe:
                    {
                        if (Cache.Cache.QRSubscribeHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.QRSubscribeHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.Unsubscribe:
                    {
                        if (Cache.Cache.UnsubscribeHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.UnsubscribeHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.QRScan:
                    {
                        if (Cache.Cache.QRScanHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.QRScanHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.UploadLocation:
                    {
                        if (Cache.Cache.UploadLocationHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.UploadLocationHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        else
                        {
                            this.DbProcess = true;
                        }
                        break;
                    }
                case RequestMessageType.MenuButtonClick:
                    {
                        if (Cache.Cache.MenuButtonClickHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            MenuButtonClickMessage menuButtonClickMessage = this.RequestMessage as MenuButtonClickMessage;
                            if (menuButtonClickMessage == null)
                            {
                                this.DbProcess = true;
                                break;
                            }
                            var key = menuButtonClickMessage.EventKey.ToLower();
                            var tempDictionary = Cache.Cache.MenuButtonClickHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                            if (tempDictionary.ContainsKey(key.ToLower()) == true)
                            {
                                this.HandlerConstructorDelegate = tempDictionary[key];
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
                        if (Cache.Cache.MenuButtonViewHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.MenuButtonViewHandlerConstructorDelegates[this.RequestMessage.ToUserName];
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

            Wechat.FireGetHandlerConstructorDelegateFromCacheByMessageTypeEnd(this);
            return true;
        }
    }
}
