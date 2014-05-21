using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatLibrary.Interface.Handler;
using WechatLibrary.Model.Message.Response;

namespace Mvc4Test.Handlers
{
    public class TextHandler : ITextHandler
    {
        public WechatLibrary.Model.Message.Response.ResponseResultBase ProcessRequest(WechatLibrary.Model.Message.Request.Normal.TextMessage message, ref bool dbProcess)
        {
            return new TextResult()
            {
                Content = "aaaaa"
            };
        }
    }
}