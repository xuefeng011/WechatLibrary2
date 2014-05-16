using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WechatLibrary.Interface.Handler;

namespace WechatLibrary.Core
{
    public class Wechat
    {
        public static void ProcessRequest()
        {

        }

        public static void ProcessRequest(HttpContext context)
        {
        }

        public static void ProcessRequest(Assembly handlerAssembly)
        {
        }

        public static void ProcessRequest(HttpContext context, Assembly handlerAssembly)
        {
            context = context ?? HttpContext.Current;
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

        }
    }
}
