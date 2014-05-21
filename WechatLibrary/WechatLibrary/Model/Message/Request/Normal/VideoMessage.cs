
namespace WechatLibrary.Model.Message.Request.Normal
{
    /// <summary>
    /// 视频消息。
    /// </summary>
    public partial class VideoMessage : NormalMessageBase
    {
        private string _mediaId;

        /// <summary>
        /// 视频消息媒体 id，可以调用多媒体文件下载接口拉取数据。
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

        private string _thumbMediaId;

        /// <summary>
        /// 视频消息缩略图的媒体 id、可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId
        {
            get
            {
                return _thumbMediaId;
            }
            set
            {
                _thumbMediaId = value;
            }
        }
    }
}
