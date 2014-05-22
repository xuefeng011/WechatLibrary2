
namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 回复语音消息。
    /// </summary>
    public partial class VoiceResult : ResponseResultBase
    {
        private string _mediaId;

        /// <summary>
        /// 通过上传多媒体文件，得到的 id。
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

        /// <summary>
        /// 创建一条语音回复。
        /// </summary>
        public VoiceResult()
        {
            this.MsgType = "voice";
        }

        /// <summary>
        /// 序列化回复消息到 xml。
        /// </summary>
        /// <returns>xml。</returns>
        public override string Serialize()
        {
            return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Voice><MediaId><![CDATA[{4}]]></MediaId></Voice></xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId);
        }
    }
}
