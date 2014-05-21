
namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 回复视频消息。
    /// </summary>
    public partial class VideoResult : ResponseResultBase
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

        private string _title;

        /// <summary>
        /// 视频消息的标题。
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        private string _description;

        /// <summary>
        /// 视频消息的描述。
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public VideoResult()
        {
            this.MsgType = "video";
        }

        /// <summary>
        /// 序列化回复消息到 xml。
        /// </summary>
        /// <returns>xml。</returns>
        public override string Serialize()
        {
            return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Video><MediaId><![CDATA[{4}]]></MediaId><Title><![CDATA[{5}]]></Title><Description><![CDATA[{6}]]></Description></Video> </xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId, Title, Description);
        }
    }
}
