using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Interface.Handler;

namespace WechatLibrary.Core.Init
{
    public partial class Init
    {
        public static void InitHandlerDelegate(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (typeof(ITextHandler).IsAssignableFrom(type) == true)
                {
                    InitTextHandlerDelegate(type);
                }
                else if (typeof(IImageHandler).IsAssignableFrom(type) == true)
                {
                    InitImageHandlerDelegate(type);
                }
                else if (typeof(IVoiceHandler).IsAssignableFrom(type) == true)
                {
                    InitVoiceHandlerDelegate(type);
                }
                else if (typeof(IVideoHandler).IsAssignableFrom(type) == true)
                {
                    InitVideoHandlerDelegate(type);
                }
                else if (typeof(ILocationHandler).IsAssignableFrom(type) == true)
                {

                }
                else if (typeof(ILinkHandler).IsAssignableFrom(type) == true)
                {

                }
                else if (typeof (ISubscribeHandler).IsAssignableFrom(type) == true)
                {
                }
                else if (typeof(IQRSubscribeHandler).IsAssignableFrom(type)==true)
                {
                    
                }
                else if (typeof(IUnsubscribeHandler).IsAssignableFrom(type)==true)
                {
                    
                }
                else if (typeof(IQRScanHandler).IsAssignableFrom(type)==true)
                {
                    
                }
            }
        }
    }
}
