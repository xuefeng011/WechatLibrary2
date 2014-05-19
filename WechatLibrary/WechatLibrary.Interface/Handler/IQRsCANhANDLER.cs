using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Request.Event;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 扫描带参数二维码事件处理接口。
    /// </summary>
    public interface IQRScanHandler
    {
        /// <summary>
        /// 处理带参数二维码事件。
        /// </summary>
        /// <param name="message">带参数二维码事件。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(QRScanMessage message, ref bool dbProcess);
    }
}
