using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool GetHttpRequestAndHttpResponse()
        {
            Wechat.FireGetHttpRequestAndHttpResponseStart(this);

            try
            {
                this.HttpRequest = this.HttpContext.Request;
                this.HttpResponse = this.HttpContext.Response;
            }
            catch (HttpException)
            {
                return false;
            }

            Wechat.FireGetHttpRequestAndHttpResponseEnd(this);
            return true;
        }
    }
}
