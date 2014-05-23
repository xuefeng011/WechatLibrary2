using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Interface.Handler;

namespace WechatLibrary.Init
{
    internal partial class Init
    {
        /// <summary>
        /// 初始化程序集中的 Handler。
        /// </summary>
        /// <param name="handlerAssembly">需要初始化的 Handler。</param>
        public static void InitHandlers(Assembly handlerAssembly)
        {
            Type[] types = handlerAssembly.GetTypes();
            foreach (var type in types)
            {
                if (typeof(ITextHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.TextHandlerConstructorDelegates,
                    Cache.Cache.TextHandlerProcessRequestMethods);
                }
                if (typeof(IImageHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.ImageHandlerConstructorDelegates, Cache.Cache.ImageHandlerProcessRequestMethods);
                }
                if (typeof(IVoiceHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.VoiceHandlerConstructorDelegates, Cache.Cache.VoiceHandlerProcessRequestMethods);
                }
                if (typeof(IVideoHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.VideoHandlerConstructorDelegates, Cache.Cache.VideoHandlerProcessRequestMethods);
                }
                if (typeof(ILocationHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.LocationHandlerConstructorDelegates, Cache.Cache.LocationHandlerProcessRequestMethods);
                }
                if (typeof(ILinkHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.LinkHandlerConstructorDelegates, Cache.Cache.LinkHandlerProcessRequestMethods);
                }
                if (typeof(ISubscribeHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.SubscribeHandlerConstructorDelegates, Cache.Cache.SubscribeHandlerProcessRequestMethods);
                }
                if (typeof(IQRSubscribeHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.QRSubscribeHandlerConstructorDelegates, Cache.Cache.QRSubscribeHandlerProcessRequestMethods);
                }
                if (typeof(IUnsubscribeHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.UnsubscribeHandlerConstructorDelegates, Cache.Cache.UnsubscribeHandlerProcessRequestMethods);
                }
                if (typeof(IQRScanHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.QRScanHandlerConstructorDelegates, Cache.Cache.QRScanHandlerProcessRequestMethods);
                }
                if (typeof(IUploadLocationHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.UploadLocationHandlerConstructorDelegates, Cache.Cache.UploadLocationHandlerProcessRequestMethods);
                }
                if (typeof(IMenuButtonClickHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.MenuButtonClickHandlerConstructorDelegates, Cache.Cache.MenuButtonClickHandlerProcessRequestMethods);
                }
                if (typeof(IMenuButtonViewHandler).IsAssignableFrom(type) == true)
                {
                    InitHandler(type, Cache.Cache.MenuButtonViewHandlerConstructorDelegates, Cache.Cache.MenuButtonViewHandlerProcessRequestMethods);
                }
            }
        }
    }
}
