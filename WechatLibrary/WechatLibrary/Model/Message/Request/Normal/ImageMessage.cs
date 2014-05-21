
namespace WechatLibrary.Model.Message.Request.Normal
{
    /// <summary>
    /// 图片消息。
    /// </summary>
    public partial class ImageMessage : NormalMessageBase
    {
        private string _picUrl;

        /// <summary>
        /// 图片链接。
        /// </summary>
        public string PicUrl
        {
            get
            {
                return _picUrl;
            }
            set
            {
                _picUrl = value;
            }
        }

        private string _mediaId;

        /// <summary>
        /// 图片消息媒体 id，可以调用多媒体文件下载接口拉取数据。
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
    }
}
