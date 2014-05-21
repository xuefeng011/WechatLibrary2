using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Cache
{
    public partial class Cache
    {
        /// <summary>
        /// 指示是否已经初始化。
        /// </summary>
        public static bool HasInit = false;

        /// <summary>
        /// 用于线程锁，防止多次初始化。
        /// </summary>
        public static object HasInitLock = new object();
    }
}
