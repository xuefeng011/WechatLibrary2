using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Core.Route
{
    public partial class Route
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

        public Route(HttpContext context)
        {
            this.HttpContext = context;
        }

        public void Start()
        {
            this.GetHttpRequestAndHttpResponse();
            this.ReadRequestXml();
            this.ParseXmlToXDocument();
            this.GetMessageTypeFromXDocument();
            this.DeserializeXDocumentByMessageType();
            this.GetHandlerDelegateFromCache();
            this.InvokeHandlerDelegateIfHandlerDelegateExist();
        }
    }
}
