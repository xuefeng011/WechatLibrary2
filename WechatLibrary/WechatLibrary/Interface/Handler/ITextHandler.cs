using WechatLibrary.Model.Message.Request.Normal;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 文本消息处理接口。
    /// </summary>
    public partial interface ITextHandler
    {
        /// <summary>
        /// 处理文本消息。
        /// </summary>
        /// <param name="message">文本消息。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(TextMessage message, ref bool dbProcess);
    }
}
