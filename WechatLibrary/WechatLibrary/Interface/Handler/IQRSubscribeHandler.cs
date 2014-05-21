using WechatLibrary.Model.Message.Request.Event;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 扫描二维码关注事件处理接口。
    /// </summary>
    public partial interface IQRSubscribeHandler
    {
        /// <summary>
        /// 处理扫描二维码关注事件。
        /// </summary>
        /// <param name="message">扫描二维码关注事件。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(QRSubscribeMessage message, ref bool dbProcess);
    }
}
