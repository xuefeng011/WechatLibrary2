using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core
{
    public partial class Wechat
    {
        public static event EventHandler GetHttpRequestAndHttpResponseStart;
        public static event EventHandler GetHttpRequestAndHttpResponseEnd;
        public static event EventHandler ReadRequestXmlStart;
        public static event EventHandler ReadRequestXmlEnd;
        public static event EventHandler ParseXmlToXDocumentStart;
        public static event EventHandler ParseXmlToXDocumentEnd;

        public static void FireGetHttpRequestAndHttpResponseStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHttpRequestAndHttpResponseStart != null)
            {
                GetHttpRequestAndHttpResponseStart(processPipeline, EventArgs.Empty);
            }
        }

        public static void FireGetHttpRequestAndHttpResponseEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHttpRequestAndHttpResponseEnd != null)
            {
                GetHttpRequestAndHttpResponseEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static void FireReadRequestXmlStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ReadRequestXmlStart != null)
            {
                ReadRequestXmlStart(processPipeline, EventArgs.Empty);
            }
        }

        public static void FireReadRequestXmlEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ReadRequestXmlEnd != null)
            {
                ReadRequestXmlEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static void FireParseXmlToXDocumentStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ParseXmlToXDocumentStart != null)
            {
                ParseXmlToXDocumentStart(processPipeline, EventArgs.Empty);
            }
        }

        public static void FireParseXmlToXDocumentEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ParseXmlToXDocumentEnd != null)
            {
                ParseXmlToXDocumentEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static void FireGetMessageTypeFromXDocumentStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
        }

        public static void FireGetMessageTypeFromXDocumentEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
        }

        public static void FireDeserializeXDocumentByMessageTypeStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
        }

        public static void FireDeserializeXDocumentByMessageTypeEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
        }

        public static void FireGetHandlerConstructorDelegateFromCacheByMessageTypeStart(ProcessPipeline.ProcessPipeline processPipeline)
        {

        }

        public static void FireGetHandlerConstructorDelegateFromCacheByMessageTypeEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
        }
    }
}
