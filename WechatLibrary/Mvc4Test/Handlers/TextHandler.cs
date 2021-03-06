﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatLibrary.Interface.Handler;
using WechatLibrary.Model.Message.Response;
using WechatLibrary.Service;

namespace Mvc4Test.Handlers
{
    public class TextHandler : ITextHandler
    {
        public WechatLibrary.Model.Message.Response.ResponseResultBase ProcessRequest(WechatLibrary.Model.Message.Request.Normal.TextMessage message, ref bool dbProcess)
        {
            string prev = MessageLogService.GetPrevTextMessageContent(message) ?? string.Empty;

            dbProcess = true;

            return new TextResult()
            {
                Content = "上一条消息内容为：" + prev
            };
        }
    }
}