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
        public void GetHandlerDelegateFromCacheByMessageType()
        {
            switch (this.RequestMessageType)
            {
                case "text":
                    {
                        if (Cache.Cache.TextHandlerDelegates.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerDelegate = Cache.Cache.TextHandlerDelegates[this.RequestMessage.ToUserName];
                        }
                        break;
                    }
            }
        }
    }
}
