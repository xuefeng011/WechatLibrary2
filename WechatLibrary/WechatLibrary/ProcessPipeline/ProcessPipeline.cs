using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.ProcessPipeline
{
    /// <summary>
    /// 用户消息处理管道。
    /// </summary>
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 存放处理的 Http 上下文。
        /// </summary>
        public HttpContext HttpContext
        {
            get;
            set;
        }

        /// <summary>
        /// 存放处理的 Http 上下文的请求。
        /// </summary>
        public HttpRequest HttpRequest
        {
            get;
            set;
        }

        /// <summary>
        /// 存放处理的 Http 上下文的响应。
        /// </summary>
        public HttpResponse HttpResponse
        {
            get;
            set;
        }

        /// <summary>
        /// 存放请求消息。
        /// </summary>
        public string RequestXml
        {
            get;
            set;
        }

        /// <summary>
        /// 存放请求消息。
        /// </summary>
        public XDocument RequestXDocument
        {
            get;
            set;
        }

        /// <summary>
        /// 存放请求消息类型。
        /// </summary>
        public RequestMessageType RequestMessageType
        {
            get;
            set;
        }

        /// <summary>
        /// 存放请求消息。
        /// </summary>
        public RequestMessageBase RequestMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 存放处理类的构造函数委托。
        /// </summary>
        public Delegate HandlerConstructorDelegate
        {
            get;
            set;
        }

        /// <summary>
        /// 指示本次请求是否使用数据库处理。
        /// </summary>
        public bool DbProcess
        {
            get;
            set;
        }

        /// <summary>
        /// 存放处理类的 ProcessRequest 方法。
        /// </summary>
        public MethodInfo HandlerProcessRequestMethod
        {
            get;
            set;
        }

        /// <summary>
        /// 存放回复消息。
        /// </summary>
        public ResponseResultBase ResponseResult
        {
            get;
            set;
        }

        /// <summary>
        /// 创建微信消息处理管道。
        /// </summary>
        /// <param name="context">处理的 Http 上下文。</param>
        public ProcessPipeline(HttpContext context)
        {
            this.HttpContext = context;
        }

        /// <summary>
        /// 开始处理管道事件。
        /// </summary>
        public void Start()
        {
            for (var temp = 0; temp < 1; temp++)
            {
                if (this.GetHttpRequestAndHttpResponse() == false)
                {
                    break;
                }
                if (this.ReadRequestXml() == false)
                {
                    break;
                }
                if (this.ParseXmlToXDocument() == false)
                {
                    break;
                }
                if (this.GetMessageTypeFromXDocument() == false)
                {
                    break;
                }
                if (this.DeserializeXDocumentByMessageType() == false)
                {
                    break;
                }
                if (this.CheckHadResponseCurrentNormalMessage() == false)
                {
                    break;
                }
                if (this.LogMessage() == false)
                {
                    break;
                }
                if (this.GetHandlerConstructorDelegateFromCacheByMessageType() == false)
                {
                    break;
                }
                if (this.GetHandlerProcessRequestMethodFromCacheByMessageType() == false)
                {
                    break;
                }
                if (this.InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExist() == false)
                {
                    break;
                }
                if (this.ExecuteDataBaseProcess() == false)
                {
                    break;
                }
                if (this.SetDefaultValue() == false)
                {
                    break;
                }
                break;
            }

            this.SerializeResponseResultAndWriteToResponseStream();
        }
    }
}
