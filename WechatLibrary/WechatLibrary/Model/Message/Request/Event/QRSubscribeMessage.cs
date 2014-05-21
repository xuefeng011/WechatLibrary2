
namespace WechatLibrary.Model.Message.Request.Event
{
    /// <summary>
    /// 扫描二维码关注事件。
    /// </summary>
    public partial class QRSubscribeMessage : EventMessageBase
    {
        private string _eventKey;

        /// <summary>
        /// 事件 KEY 值，qrscene_ 为前缀，后面为二维码的参数值。
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

        private string _ticket;

        /// <summary>
        /// 二维码的 ticket，可用来换取二维码图片。
        /// </summary>
        public string Ticket
        {
            get
            {
                return _ticket;
            }
            set
            {
                _ticket = value;
            }
        }
    }
}
