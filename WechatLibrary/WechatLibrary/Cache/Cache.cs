
namespace WechatLibrary.Cache
{
    /// <summary>
    /// 微信类库缓存，主要缓存处理类的构造函数和 ProcessRequest 方法。
    /// </summary>
    internal partial class Cache
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
