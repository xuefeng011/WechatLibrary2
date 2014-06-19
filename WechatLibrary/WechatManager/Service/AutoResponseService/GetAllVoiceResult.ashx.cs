using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatManager.Service.AutoResponseService
{
    /// <summary>
    /// GetAllVoiceResult 的摘要说明
    /// </summary>
    public class GetAllVoiceResult : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}