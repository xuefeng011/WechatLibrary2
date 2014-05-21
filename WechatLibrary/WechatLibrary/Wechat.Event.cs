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
