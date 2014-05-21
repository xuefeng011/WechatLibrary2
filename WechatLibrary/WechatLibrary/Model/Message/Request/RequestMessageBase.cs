
namespace WechatLibrary.Model.Message.Request
{
    /// <summary>
    /// 接收消息基类。
    /// </summary>
    public abstract partial class RequestMessageBase
    {
        private string _toUserName;

        /// <summary>
        /// 开发者微信号。
        /// </summary>
        public string ToUserName
        {
            get
            {
                return _toUserName;
            }
            set
            {
                _toUserName = value;
            }
        }

        private string _fromUserName;

        /// <summary>
        /// 发送方帐号（一个 OpenID）。
        /// </summary>
        public string FromUserName
        {
            get
            {
                return _fromUserName;
            }
            set
            {
                _fromUserName = value;
            }
        }

        private int _createTime;

        /// <summary>
        /// 消息创建时间（整型）。
        /// </summary>
        public int CreateTime
        {
            get
            {
                return _createTime;
            }
            set
            {
                _createTime = value;
            }
        }

        private string _msgType;

        /// <summary>
        /// 消息类型。
        /// </summary>
        public string MsgType
        {
            get
            {
                return _msgType;
            }
            set
            {
                _msgType = value;
            }
        }
    }
}
