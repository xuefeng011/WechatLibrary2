using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.Cache
{
    public partial class Cache
    {
        public static bool HasInit = false;

        public static object HasInitLock = new object();
    }
}
