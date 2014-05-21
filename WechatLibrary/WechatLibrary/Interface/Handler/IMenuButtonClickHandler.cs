using WechatLibrary.Model.Message.Request.Event;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 自定义菜单点击事件处理接口。
    /// </summary>
    public partial interface IMenuButtonClickHandler
    {
        /// <summary>
        /// 处理自定义菜单点击事件。
        /// </summary>
        /// <param name="message">自定义菜单点击事件。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(MenuButtonClickMessage message, ref bool dbProcess);
    }
}
