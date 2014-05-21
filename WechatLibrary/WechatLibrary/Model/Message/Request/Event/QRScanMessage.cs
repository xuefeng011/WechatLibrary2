
namespace WechatLibrary.Model.Message.Request.Event
{
    /// <summary>
    /// 扫描带参数二维码事件。
    /// </summary>
    public partial class QRScanMessage : EventMessageBase
    {
        private string _eventKey;

        /// <summary>
        /// 事件 KEY 值，是一个 32 位无符号整数，即创建二维码时的二维码 scene_id。
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
