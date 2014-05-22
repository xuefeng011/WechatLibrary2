using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Cache
{
    internal partial class Cache
    {
        /// <summary>
        /// 缓存文本消息处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> TextHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存图片消息处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> ImageHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存语音消息处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> VoiceHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存视频消息处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> VideoHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存地理位置消息处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> LocationHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存链接消息处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> LinkHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存关注事件处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> SubscribeHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存扫描二维码关注事件处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> QRSubscribeHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存取消关注事件处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> UnsubscribeHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存扫描带参数二维码事件处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> QRScanHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存上传地理位置事件处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> UploadLocationHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存自定义菜单点击事件处理类的 ProcessRequest 方法。
        /// Key1：开发者微信 Id。
        /// Key2：自定义菜单按钮的 Key 值。
        /// </summary>
        public static volatile ConcurrentDictionary<string, ConcurrentDictionary<string, MethodInfo>> MenuButtonClickHandlerProcessRequestMethods = new ConcurrentDictionary<string, ConcurrentDictionary<string, MethodInfo>>();

        /// <summary>
        /// 缓存自定义菜单跳转事件处理类的 ProcessRequest 方法。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile ConcurrentDictionary<string, MethodInfo> MenuButtonViewHandlerProcessRequestMethods = new ConcurrentDictionary<string, MethodInfo>();
    }
}
