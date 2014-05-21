
namespace WechatLibrary.Model.Message.Request.Event
{
    /// <summary>
    /// 自定义菜单点击事件。
    /// </summary>
    public partial class MenuButtonClickMessage : EventMessageBase
    {
        private string _eventKey;

        /// <summary>
        /// 事件 KEY 值，与自定义菜单接口中 KEY 值对应。
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
