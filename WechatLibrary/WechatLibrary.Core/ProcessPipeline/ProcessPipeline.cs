using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public HttpContext HttpContext
        {
            get;
            set;
        }

        public HttpRequest HttpRequest
        {
            get;
            set;
        }

        public HttpResponse HttpResponse
        {
            get;
            set;
        }

        public string RequestXml
        {
            get;
            set;
        }

        public XDocument RequestXDocument
        {
            get;
            set;
        }

        public string RequestMessageType
        {
            get;
            set;
        }

        public RequestMessageBase RequestMessage
        {
            get;
            set;
        }

        public ResponseResultBase ResponseResult
        {
            get;
            set;
        }

        public Delegate HandlerDelegate
        {
            get;
            set;
        }

        public bool DbProcess
        {
            get;
            set;
        }

        /// <summary>
        /// 以 Http 上下文创建一个微信消息路由。
        /// </summary>
        /// <param name="context"></param>
        public ProcessPipeline(HttpContext context)
        {
            this.HttpContext = context;
        }

        /// <summary>
        /// 开始消息处理管道。
        /// </summary>
        public void Start()
        {
            try
            {
                this.GetHttpRequestAndHttpResponse();
                this.ReadRequestXml();
                this.ParseXmlToXDocument();
                this.GetMessageTypeFromXDocument();
                this.DeserializeXDocumentByMessageType();
                this.GetHandlerDelegateFromCache();
                this.InvokeHandlerDelegateIfHandlerDelegateExist();
            }
            catch (Exception)
            {
            }
            finally
            {

            }
        }
    }
}
