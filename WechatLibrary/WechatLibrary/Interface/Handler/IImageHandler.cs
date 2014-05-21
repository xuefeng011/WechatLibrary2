using WechatLibrary.Model.Message.Request.Normal;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 图片消息处理接口。
    /// </summary>
    public partial interface IImageHandler
    {
        /// <summary>
        /// 处理图片消息。
        /// </summary>
        /// <param name="message">图片消息。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(ImageMessage message, ref bool dbProcess);
    }
}
