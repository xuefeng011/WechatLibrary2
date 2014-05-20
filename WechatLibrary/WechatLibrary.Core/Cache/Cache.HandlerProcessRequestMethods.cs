using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.Cache
{
    public partial class Cache
    {
        /// <summary>
        /// 缓存文本消息处理的处理函数。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile Dictionary<string, MethodInfo> TextHandlerProcessRequestMethods = new Dictionary<string, MethodInfo>();

        /// <summary>
        /// 缓存图片消息处理的处理函数。
        /// Key：开发者微信 Id。
        /// </summary>
        public static volatile Dictionary<string, MethodInfo> ImageHandlerProcessRequestMethods = new Dictionary<string, MethodInfo>();
    }
}
