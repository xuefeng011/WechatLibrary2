
namespace WechatLibrary.Model.Message.Request.Normal
{
    /// <summary>
    /// 语音消息。
    /// </summary>
    public partial class VoiceMessage : NormalMessageBase
    {
        private string _mediaId;

        /// <summary>
        /// 语音消息媒体 id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId
        {
            get
            {
                return _mediaId;
            }
            set
            {
                _mediaId = value;
            }
        }

        private string _format;

        /// <summary>
        /// 语音消息，如 amr，speex 等。
        /// </summary>
        public string Format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = value;
            }
        }

        private string _recognition;

        /// <summary>
        /// 语音识别结果，UTF8 编码。
        /// </summary>
        public string Recognition
        {
            get
            {
                return _recognition;
            }
            set
            {
                _recognition = value;
            }
        }
    }
}
