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



        public static void Init(Assembly assembly)
        {
        }


        public static void InitRoute(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            Type[] textHandlerTypes = types.Where(temp => typeof(ITextHandler).IsAssignableFrom(temp) == true).ToArray();
            foreach (var textHandlerType in textHandlerTypes)
            {
                Action a = () => { string s = "aaa"; };
                TextHandlerCollection.Dictionary.Add("",a );
            }
        }
    }

    internal class TextHandlerCollection
    {
        public static Dictionary<string, Delegate> Dictionary;

        public Delegate this[string s]
        {
            get
            {
                return Dictionary[s];
            }
        }
    }
}
