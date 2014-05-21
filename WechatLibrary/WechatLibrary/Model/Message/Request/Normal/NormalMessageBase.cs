
namespace WechatLibrary.Model.Message.Request.Normal
{
    /// <summary>
    /// 普通消息基类。
    /// </summary>
    public abstract partial class NormalMessageBase : RequestMessageBase
    {
        private long _msgId;

        /// <summary>
        /// 消息 id，64位 整型。
        /// </summary>
        public long MsgId
        {
            get
            {
                return _msgId;
            }
            set
            {
                _msgId = value;
            }
        }
    }
}
