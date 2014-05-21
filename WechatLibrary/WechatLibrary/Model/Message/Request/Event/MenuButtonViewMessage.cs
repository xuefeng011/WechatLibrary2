
namespace WechatLibrary.Model.Message.Request.Event
{
    /// <summary>
    /// 自定义菜单跳转事件。
    /// </summary>
    public partial class MenuButtonViewMessage : EventMessageBase
    {
        private string _eventKey;

        /// <summary>
        /// 事件 KEY 值，设置的跳转 URL 。
        /// </summary>
        public string EventKey
        {
            get
            {
                return _eventKey;
            }
            set
            {
                _eventKey = value;
            }
        }
    }
}
