using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.Route
{
    public partial class Route
    {
        public void GetHandlerDelegateFromCache()
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
