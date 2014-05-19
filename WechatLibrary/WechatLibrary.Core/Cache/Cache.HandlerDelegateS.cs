using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.Cache
{
    public partial class Cache
    {
        /// <summary>
        /// 缓存文本消息处理的构造函数。
        /// Key：消息接收方微信 Id。
        /// </summary>
        public static volatile Dictionary<string, Delegate> TextHandlerDelegates = new Dictionary<string, Delegate>();

        /// <summary>
        /// 缓存图片消息处理的构造函数。
        /// Key：消息接收方微信 Id。
        /// </summary>
        public static volatile Dictionary<string, Delegate> ImageHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> VoiceHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> VideoHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> LocationHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> LinkHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> SubscribeHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> QRSubscribeHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> UnsubscribeDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> QRScanDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> UploadLocationDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> MenuButtonDelegates = new Dictionary<string, Delegate>();
    }
}
