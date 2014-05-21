
namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 不回复消息。
    /// </summary>
    public partial class EmptyResult : ResponseResultBase
    {
        /// <summary>
        /// 序列化回复消息到 xml。
        /// </summary>
        /// <returns>xml。</returns>
        public override string Serialize()
        {
            return string.Empty;
        }
    }
}
