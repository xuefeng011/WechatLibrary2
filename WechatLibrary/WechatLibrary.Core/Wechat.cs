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
    public class Wechat
    {
        public static void ProcessRequest()
        {
            ProcessRequest(HttpContext.Current, Assembly.GetCallingAssembly());
        }

        public static void ProcessRequest(HttpContext context)
        {
            ProcessRequest(context, Assembly.GetCallingAssembly());
        }

        public static void ProcessRequest(Assembly handlerAssembly)
        {
            ProcessRequest(HttpContext.Current, handlerAssembly);
        }

        public static void ProcessRequest(HttpContext context, Assembly handlerAssembly)
        {
            context = context ?? HttpContext.Current;
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (Cache.Cache.HasInit == false)
            {
                lock (Cache.Cache.HasInitLock)
                {
                    if (Cache.Cache.HasInit == false)
                    {
                        Init.Init.InitHandlerDelegate(handlerAssembly);
                        Cache.Cache.HasInit = true;
                    }
                }
            }

            string method = context.Request.HttpMethod;
            if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase) == true)
            {
               
            }
            else if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase) == true)
            {
                Signature.Signature.DoSignature(context);
            }
        }
    }
}
