using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.Cache
{
    public partial class Cache
    {
        public static volatile Dictionary<string, Delegate> TextHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> ImageHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> VoiceHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> VideoHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> LocationHandlerDelegates = new Dictionary<string, Delegate>();

        public static volatile Dictionary<string, Delegate> LinkHandlerDelegates = new Dictionary<string, Delegate>();
    }
}
