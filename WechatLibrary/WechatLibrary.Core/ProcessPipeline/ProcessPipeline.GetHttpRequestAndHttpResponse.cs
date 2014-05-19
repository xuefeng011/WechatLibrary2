using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WechatLibrary.Model.Exception;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 从 Http 上下文中获取 Http 请求与响应。
        /// </summary>
        public void GetHttpRequestAndHttpResponse()
        {
            try
            {
                this.HttpRequest = this.HttpContext.Request;
            }
            catch (HttpException ex)
            {
                throw new WechatProcessRequestException("获取 Http 请求失败！", ex);
            }
            try
            {
                this.HttpResponse = this.HttpContext.Response;
            }
            catch (HttpException ex)
            {
                throw new WechatProcessRequestException("获取 Http 响应失败！", ex);
            }
        }
    }
}
