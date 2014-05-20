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
        /// 根据消息类型，从缓存中获取 Handler 的构造函数委托。
        /// </summary>
        public void GetHandlerConstructorDelegateFromCacheByMessageType()
        {
            switch (this.RequestMessageType)
            {
                case "text":
                    {
                        if (Cache.Cache.TextHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.TextHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        break;
                    }
                case "image":
                    {
                        if (Cache.Cache.ImageHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.ImageHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        break;
                    }
                case "voice":
                    {
                        if (Cache.Cache.VoiceHandlerConstructorDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerConstructorDelegate = Cache.Cache.VoiceHandlerConstructorDelegates[this.RequestMessage.ToUserName];
                        }
                        break;
                    }
                case "video":
                case "location":
                case "link":
                case "subscribe":
                case "qrsubscribe":
                case "unsubscribe":
                case "scan":
                case "uploadlocation":
                case "click":
                    {
                        break;
                    }
            }
        }
    }
}
