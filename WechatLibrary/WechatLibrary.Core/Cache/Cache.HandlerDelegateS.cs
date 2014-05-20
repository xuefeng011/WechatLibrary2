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
        /// 缓存文本消息处理的构造函数委托。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile Dictionary<string, Delegate> TextHandlerConstructorDelegates = new Dictionary<string, Delegate>();
        
        /// <summary>
        /// 缓存图片消息处理的构造函数委托。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile Dictionary<string, Delegate> ImageHandlerConstructorDelegates = new Dictionary<string, Delegate>();














        public static volatile Dictionary<string, Delegate> VoiceHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> VideoHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> LocationHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> LinkHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> SubscribeHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> QRSubscribeHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> UnsubscribeHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> QRScanHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> UploadLocationHandlerConstructorDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> MenuButtonHandlerConstructorDelegates = new Dictionary<string, Delegate>();
    }
}
