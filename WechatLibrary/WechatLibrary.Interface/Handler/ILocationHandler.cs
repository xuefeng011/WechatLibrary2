﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Interface.Handler
{
    /// <summary>
    /// 地理位置消息处理接口。
    /// </summary>
    public interface ILocationHandler
    {
        /// <summary>
        /// 处理地理位置消息。
        /// </summary>
        /// <param name="message">地理位置消息。</param>
        /// <param name="dbProcess">是否由数据库处理。默认 false。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(LocationMessage message, ref bool dbProcess);
    }
}
