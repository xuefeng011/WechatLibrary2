using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public void GetHttpRequestAndHttpResponse()
        {
            this.HttpRequest = this.HttpContext.Request;
            this.HttpResponse = this.HttpContext.Response;
        }
    }
}
