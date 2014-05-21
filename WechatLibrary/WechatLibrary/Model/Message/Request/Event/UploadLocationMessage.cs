
namespace WechatLibrary.Model.Message.Request.Event
{
    /// <summary>
    /// 上报地理位置事件。
    /// </summary>
    public partial class UploadLocationMessage : EventMessageBase
    {
        private double _latitude;

        /// <summary>
        /// 地理位置纬度。
        /// </summary>
        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
            }
        }

        private double _longitude;

        /// <summary>
        /// 地理位置经度。
        /// </summary>
        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
            }
        }

        private double _precision;

        /// <summary>
        /// 地理位置精度。
        /// </summary>
        public double Precision
        {
            get
            {
                return _precision;
            }
            set
            {
                _precision = value;
            }
        }
    }
}
