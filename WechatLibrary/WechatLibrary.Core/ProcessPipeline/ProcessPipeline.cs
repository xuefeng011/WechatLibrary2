using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using WechatLibrary.Model.Exception;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Core.ProcessPipeline
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
        public string RequestMessageType
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
        /// 存放回复消息。
        /// </summary>
        public ResponseResultBase ResponseResult
        {
            get;
            set;
        }

        /// <summary>
        /// 存放 Handler 类的构造函数。
        /// </summary>
        public Delegate HandlerConstructorDelegate
        {
            get;
            set;
        }

        /// <summary>
        /// 存放 Handler 类的 ProcessRequest 方法。
        /// </summary>
        public MethodInfo HandlerProcessRequestMethod
        {
            get;
            set;
        }

        /// <summary>
        /// 是否由数据库处理。
        /// 存在 HandlerDelegate 情况下，默认 false。
        /// 不存在 HandlerDelegate 情况下，默认 true。
        /// </summary>
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

                this.GetHandlerConstructorDelegateFromCacheByMessageType();

                this.GetHandlerProcessRequestMethodFromCacheByMessageType();

                this.InvokeHandlerDelegateIfHandlerDelegateExist();

#warning go to db here

                this.SetDefaultValue();
            }
            catch (WechatProcessRequestException ex)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.SerializeResponseResultAndWriteToResponseStream();
            }
        }
    }
}
