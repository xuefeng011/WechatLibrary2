using WechatLibrary.Model.Message.Request.Normal;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 链接消息处理接口。
    /// </summary>
    public partial interface ILinkHandler
    {
        /// <summary>
        /// 处理链接消息。
        /// </summary>
        /// <param name="message">链接消息。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(LinkMessage message, ref bool dbProcess);
    }
}
