using WechatLibrary.Model.Message.Request.Normal;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 语音消息处理接口。
    /// </summary>
    public partial interface IVoiceHandler
    {
        /// <summary>
        /// 处理语音消息。
        /// </summary>
        /// <param name="message">语音消息。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(VoiceMessage message, ref bool dbProcess);
    }
}
