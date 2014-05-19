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
    /// 上报地理位置事件处理接口。
    /// </summary>
    public interface IUploadLocationHandler
    {
        /// <summary>
        /// 处理上报地理位置事件。
        /// </summary>
        /// <param name="message">上报地理位置事件。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(UploadLocationMessage message, ref bool dbProcess);
    }
}
