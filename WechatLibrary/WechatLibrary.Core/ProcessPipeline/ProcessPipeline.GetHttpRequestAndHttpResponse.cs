using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 从 Http 上下文中获取 Http 请求与响应。
        /// </summary>
        public void GetHttpRequestAndHttpResponse()
        {
            this.HttpRequest = this.HttpContext.Request;
            this.HttpResponse = this.HttpContext.Response;
        }
    }
}
