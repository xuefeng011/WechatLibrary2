
namespace WechatLibrary.Model.Message.Request.Normal
{
    /// <summary>
    /// 地理位置消息。
    /// </summary>
    public partial class LocationMessage : NormalMessageBase
    {
        private double _location_X;

        /// <summary>
        /// 地理位置维度。
        /// </summary>
        public double Location_X
        {
            get
            {
                return _location_X;
            }
            set
            {
                _location_X = value;
            }
        }

        private double _location_Y;

        /// <summary>
        /// 地理位置经度。
        /// </summary>
        public double Location_Y
        {
            get
            {
                return _location_Y;
            }
            set
            {
                _location_Y = value;
            }
        }

        private double _scale;

        /// <summary>
        /// 地图缩放大小。
        /// </summary>
        public double Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }

        private string _label;

        /// <summary>
        /// 地理位置信息。
        /// </summary>
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
            }
        }
    }
}
