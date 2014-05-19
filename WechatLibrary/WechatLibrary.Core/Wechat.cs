using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WechatLibrary.Interface.Handler;

namespace WechatLibrary.Core
{
    /// <summary>
    /// 微信类库入口。
    /// </summary>
    public partial class Wechat
    {
        /// <summary>
        /// 处理微信用户消息。
        /// </summary>
        /// <exception cref="System.ArgumentNullException">执行的 Http 上下文为 null。</exception>
        public static void ProcessRequest()
        {
            ProcessRequest(HttpContext.Current, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// 处理微信用户消息。
        /// </summary>
        /// <param name="context">执行的 Http 上下文。</param>
        /// <exception cref="System.ArgumentNullException">执行的 Http 上下文为 null。</exception>
        public static void ProcessRequest(HttpContext context)
        {
            ProcessRequest(context, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// 处理微信用户消息。
        /// </summary>
        /// <param name="handlerAssembly">Handler 所在程序集。</param>
        /// <exception cref="System.ArgumentNullException">执行的 Http 上下文为 null。</exception>
        public static void ProcessRequest(Assembly handlerAssembly)
        {
            ProcessRequest(HttpContext.Current, handlerAssembly);
        }

        /// <summary>
        /// 处理微信用户消息。
        /// </summary>
        /// <param name="context">执行的 Http 上下文。</param>
        /// <param name="handlerAssembly">Handler 所在程序集。</param>
        /// <exception cref="System.ArgumentNullException">执行的 Http 上下文为 null。</exception>
        public static void ProcessRequest(HttpContext context, Assembly handlerAssembly)
        {
            // 尝试获取当前线程上的 Http 上下文。
            context = context ?? HttpContext.Current;
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            // 判断是否已经进行初始化。
            if (Cache.Cache.HasInit == false)
            {
                // 锁加双判断，确定线程不冲突。
                lock (Cache.Cache.HasInitLock)
                {
                    if (Cache.Cache.HasInit == false)
                    {
                        // 缓存 Handler。
                        Init.Init.InitHandlerDelegate(handlerAssembly);

                        // 标识已经执行过初始化。
                        Cache.Cache.HasInit = true;
                    }
                }
            }

            try
            {
                HttpRequest request = context.Request;

                // 获取该次 Http 请求的方法。
                string method = request.HttpMethod;

                if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase) == true)
                {
                    // Post 请求，创建处理管道，处理用户消息。
                    ProcessPipeline.ProcessPipeline route = new ProcessPipeline.ProcessPipeline(context);
                    route.Start();
                }
                else if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase) == true)
                {
                    // Get 请求，执行 URL 验证。
                    Signature.Signature.DoSignature(context);
                }
            }
            catch (HttpException)
            {
                // 无法获取 Request，放弃执行此次微信请求。
            }
        }
    }
}
