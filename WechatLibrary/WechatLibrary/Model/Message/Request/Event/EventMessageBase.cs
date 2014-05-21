
namespace WechatLibrary.Model.Message.Request.Event
{
    /// <summary>
    /// 事件消息基类。
    /// </summary>
    public abstract class EventMessageBase : RequestMessageBase
    {
        private string _event;

        /// <summary>
        /// 事件类型。
        /// </summary>
        public string Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }
    }
}
