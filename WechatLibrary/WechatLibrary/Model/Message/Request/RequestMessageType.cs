using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request
{
    /// <summary>
    /// 请求消息类型。
    /// </summary>
    public enum RequestMessageType
    {
        /// <summary>
        /// 未知消息类型。
        /// </summary>
        Unknown,

        /// <summary>
        /// 文本消息。
        /// </summary>
        Text,

        /// <summary>
        /// 图片消息。
        /// </summary>
        Image,

        /// <summary>
        /// 语音消息。
        /// </summary>
        Voice,

        /// <summary>
        /// 视频消息。
        /// </summary>
        Video,

        /// <summary>
        /// 地理位置消息。
        /// </summary>
        Location,

        /// <summary>
        /// 链接消息。
        /// </summary>
        Link,

        /// <summary>
        /// 关注事件。
        /// </summary>
        Subscribe,

        /// <summary>
        /// 扫描二维码关注事件。
        /// </summary>
        QRSubscribe,

        /// <summary>
        /// 取消关注事件。
        /// </summary>
        Unsubscribe,

        /// <summary>
        /// 扫描二维码事件。
        /// </summary>
        QRScan,

        /// <summary>
        /// 上传地理位置事件。
        /// </summary>
        UploadLocation,

        /// <summary>
        /// 自定义菜单点击事件。
        /// </summary>
        MenuButtonClick,

        /// <summary>
        /// 自定义菜单跳转事件。
        /// </summary>
        MenuButtonView,
    }
}
