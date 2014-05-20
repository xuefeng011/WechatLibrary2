using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public void GetHandlerProcessRequestMethodFromCacheByMessageType()
        {
            switch (this.RequestMessageType)
            {
                case "text":
                    {
                        if (Cache.Cache.TextHandlerProcessRequestMethods.ContainsKey(this.RequestMessage.ToUserName) == true)
                        {
                            this.HandlerProcessRequestMethod = Cache.Cache.TextHandlerProcessRequestMethods[this.RequestMessage.ToUserName];
                        }
                        break;
                    }
                case "image":
                    {
                        break;
                    }
            }
        }
    }
}
