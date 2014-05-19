using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 视频消息处理接口。
    /// </summary>
    public interface IVideoHandler
    {
        /// <summary>
        /// 处理视频消息。
        /// </summary>
        /// <param name="message">视频消息。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(VideoMessage message, ref bool dbProcess);
    }
}
