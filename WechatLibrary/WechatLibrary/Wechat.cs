using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WechatLibrary
{
    /// <summary>
    /// 微信类库入口。
    /// </summary>
    public partial class Wechat
    {
        /// <summary>
        /// 处理微信请求。
        /// </summary>
        /// <exception cref="System.ArgumentNullException">执行的 Http 上下文为 null。</exception>
        public static void ProcessRequest()
        {
            ProcessRequest(HttpContext.Current, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// 处理微信请求。
        /// </summary>
        /// <param name="context">执行的 Http 上下文。</param>
        /// <exception cref="System.ArgumentNullException"><c>context</c> 为 null。</exception>
        public static void ProcessRequest(HttpContext context)
        {
            ProcessRequest(context, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// 处理微信请求。
        /// </summary>
        /// <param name="handlerAssembly">Handler 所在的程序集。</param>
        /// <exception cref="System.ArgumentNullException">执行的 Http 上下文为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>handlerAssembly</c>为 null。</exception>
        public static void ProcessRequest(Assembly handlerAssembly)
        {
            ProcessRequest(HttpContext.Current, handlerAssembly);
        }

        /// <summary>
        /// 处理微信请求。
        /// </summary>
        /// <param name="context">执行的 Http 上下文。</param>
        /// <param name="handlerAssembly">Handler 所在的程序集。</param>
        /// <exception cref="System.ArgumentNullException"><c>context</c>为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>handlerAssembly</c>为 null。</exception>
        public static void ProcessRequest(HttpContext context, Assembly handlerAssembly)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (handlerAssembly == null)
            {
                throw new ArgumentNullException("handlerAssembly");
            }

            // 判断是否已经初始化。
            if (Cache.Cache.HasInit == false)
            {
                lock (Cache.Cache.HasInitLock)
                {
                    if (Cache.Cache.HasInit == false)
                    {
                        // 缓存 Handler。




                        // 标识已经缓存。
                        Cache.Cache.HasInit = true;
                    }
                }
            }
        }
    }
}
