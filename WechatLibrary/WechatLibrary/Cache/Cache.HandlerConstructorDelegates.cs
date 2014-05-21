using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Cache
{
    public partial class Cache
    {
        /// <summary>
        /// 缓存文本消息处理类的构造函数委托。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> TextHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存图片消息处理类的构造函数委托。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> ImageHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存语音消息处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> VoiceHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存视频消息处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> VideoHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存地理位置消息处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> LocationHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存链接消息处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> LinkHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存关注事件处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> SubscribeHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存扫描二维码关注事件处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> QRSubscribeHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存取消关注事件处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> UnsubscribeHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存扫描带参数二维码事件处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> QRScanHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存上传地理位置事件处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> UploadLocationHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存自定义菜单点击事件处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> MenuButtonClickHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// 缓存自定义菜单跳转事件处理类的构造函数委托。
        /// </summary>
        public static volatile ConcurrentDictionary<string, Delegate> MenuButtonViewHandlerConstructorDelegates = new ConcurrentDictionary<string, Delegate>();
    }
}
