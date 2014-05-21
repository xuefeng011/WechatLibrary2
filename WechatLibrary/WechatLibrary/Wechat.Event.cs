using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary
{
    public partial class Wechat
    {
        public static event EventHandler GetHttpRequestAndHttpResponseStart;

        public static void FireGetHttpRequestAndHttpResponseStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHttpRequestAndHttpResponseStart != null)
            {
                GetHttpRequestAndHttpResponseStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler GetHttpRequestAndHttpResponseEnd;

        public static void FireGetHttpRequestAndHttpResponseEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHttpRequestAndHttpResponseEnd != null)
            {
                GetHttpRequestAndHttpResponseEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler ReadRequestXmlStart;

        public static void FireReadRequestXmlStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ReadRequestXmlStart != null)
            {
                ReadRequestXmlStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler ReadRequestXmlEnd;

        public static void FireReadRequestXmlEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ReadRequestXmlEnd != null)
            {
                ReadRequestXmlEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler ParseXmlToXDocumentStart;

        public static void FireParseXmlToXDocumentStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ParseXmlToXDocumentStart != null)
            {
                ParseXmlToXDocumentStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler ParseXmlToXDocumentEnd;

        public static void FireParseXmlToXDocumentEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ParseXmlToXDocumentEnd != null)
            {
                ParseXmlToXDocumentEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler GetMessageTypeFromXDocumentStart;

        public static void FireGetMessageTypeFromXDocumentStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetMessageTypeFromXDocumentStart != null)
            {
                GetMessageTypeFromXDocumentStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler GetMessageTypeFromXDocumentEnd;

        public static void FireGetMessageTypeFromXDocumentEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetMessageTypeFromXDocumentEnd != null)
            {
                GetMessageTypeFromXDocumentEnd(processPipeline, EventArgs.Empty);
            }
        }









        public static event EventHandler SerializeResponseResultAndWriteToResponseStreamStart;

        public static void FireSerializeResponseResultAndWriteToResponseStreamStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (SerializeResponseResultAndWriteToResponseStreamStart != null)
            {
                SerializeResponseResultAndWriteToResponseStreamStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler SerializeResponseResultAndWriteToResponseStreamEnd;

        public static void FireSerializeResponseResultAndWriteToResponseStreamEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (SerializeResponseResultAndWriteToResponseStreamEnd != null)
            {
                SerializeResponseResultAndWriteToResponseStreamEnd(processPipeline, EventArgs.Empty);
            }
        }
    }
}
