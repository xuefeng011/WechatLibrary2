using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary
{
    public partial class Wechat
    {
        /// <summary>
        /// 开始获取 HttpRequest 和 HttpResponse。
        /// </summary>
        public static event EventHandler GetHttpRequestAndHttpResponseStart;

        /// <summary>
        /// 触发开始获取 HttpRequest 和 HttpResponse 事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireGetHttpRequestAndHttpResponseStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHttpRequestAndHttpResponseStart != null)
            {
                GetHttpRequestAndHttpResponseStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束获取 HttpRequest 和 HttpResponse。
        /// </summary>
        public static event EventHandler GetHttpRequestAndHttpResponseEnd;

        /// <summary>
        /// 触发结束获取 HttpRequest 和 HttpResponse 事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireGetHttpRequestAndHttpResponseEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHttpRequestAndHttpResponseEnd != null)
            {
                GetHttpRequestAndHttpResponseEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始读取请求的消息 xml。
        /// </summary>
        public static event EventHandler ReadRequestXmlStart;

        /// <summary>
        /// 触发开发读取请求的消息 xml 事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireReadRequestXmlStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ReadRequestXmlStart != null)
            {
                ReadRequestXmlStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束读取请求的消息 xml。
        /// </summary>
        public static event EventHandler ReadRequestXmlEnd;

        /// <summary>
        /// 触发结束读取请求的消息 xml 事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireReadRequestXmlEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ReadRequestXmlEnd != null)
            {
                ReadRequestXmlEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始转换请求的消息 xml 到 XDocument。
        /// </summary>
        public static event EventHandler ParseXmlToXDocumentStart;

        /// <summary>
        /// 触发开始转换请求的消息 xml 到 XDocument 事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireParseXmlToXDocumentStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ParseXmlToXDocumentStart != null)
            {
                ParseXmlToXDocumentStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束转换请求的消息 xml 到 XDocument。
        /// </summary>
        public static event EventHandler ParseXmlToXDocumentEnd;

        /// <summary>
        /// 触发结束转换请求的消息 xml 到 XDocument。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireParseXmlToXDocumentEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ParseXmlToXDocumentEnd != null)
            {
                ParseXmlToXDocumentEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始从消息 XDocument 中获取消息类型。
        /// </summary>
        public static event EventHandler GetMessageTypeFromXDocumentStart;

        /// <summary>
        /// 触发开始从消息 XDocument 中获取消息类型事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireGetMessageTypeFromXDocumentStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetMessageTypeFromXDocumentStart != null)
            {
                GetMessageTypeFromXDocumentStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束从消息 XDocument 中获取消息类型。
        /// </summary>
        public static event EventHandler GetMessageTypeFromXDocumentEnd;

        /// <summary>
        /// 触发结束从消息 XDocument 中获取消息类型事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireGetMessageTypeFromXDocumentEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetMessageTypeFromXDocumentEnd != null)
            {
                GetMessageTypeFromXDocumentEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始反序列化 XDocument 到消息实例。
        /// </summary>
        public static event EventHandler DeserializeXDocumentByMessageTypeStart;

        /// <summary>
        /// 触发开发反序列化 XDocument 到消息实例事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireDeserializeXDocumentByMessageTypeStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (DeserializeXDocumentByMessageTypeStart != null)
            {
                DeserializeXDocumentByMessageTypeStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束反序列化 XDocument 到消息实例。
        /// </summary>
        public static event EventHandler DeserializeXDocumentByMessageTypeEnd;

        /// <summary>
        /// 触发结束反序列化 XDocument 到消息实例事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        public static void FireDeserializeXDocumentByMessageTypeEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (DeserializeXDocumentByMessageTypeEnd != null)
            {
                DeserializeXDocumentByMessageTypeEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler CheckHadResponseCurrentNormalMessageStart;

        public static void FireCheckHadResponseCurrentNormalMessageStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (CheckHadResponseCurrentNormalMessageStart != null)
            {
                CheckHadResponseCurrentNormalMessageStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler CheckHadResponseCurrentNormalMessageEnd;

        public static void FireCheckHadResponseCurrentNormalMessageEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (CheckHadResponseCurrentNormalMessageEnd != null)
            {
                CheckHadResponseCurrentNormalMessageEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler LogMessageStart;

        public static void FireLogMessageStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (LogMessageStart != null)
            {
                LogMessageStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler LogMessageEnd;

        public static void FireLogMessageEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (LogMessageEnd != null)
            {
                LogMessageEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler GetHandlerConstructorDelegateFromCacheByMessageTypeStart;

        public static void FireGetHandlerConstructorDelegateFromCacheByMessageTypeStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHandlerConstructorDelegateFromCacheByMessageTypeStart != null)
            {
                GetHandlerConstructorDelegateFromCacheByMessageTypeStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler GetHandlerConstructorDelegateFromCacheByMessageTypeEnd;

        public static void FireGetHandlerConstructorDelegateFromCacheByMessageTypeEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHandlerConstructorDelegateFromCacheByMessageTypeEnd != null)
            {
                GetHandlerConstructorDelegateFromCacheByMessageTypeEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler GetHandlerProcessRequestMethodFromCacheByMessageTypeStart;

        public static void FireGetHandlerProcessRequestMethodFromCacheByMessageTypeStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHandlerProcessRequestMethodFromCacheByMessageTypeStart != null)
            {
                GetHandlerProcessRequestMethodFromCacheByMessageTypeStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler GetHandlerProcessRequestMethodFromCacheByMessageTypeEnd;

        public static void FireGetHandlerProcessRequestMethodFromCacheByMessageTypeEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHandlerProcessRequestMethodFromCacheByMessageTypeEnd != null)
            {
                GetHandlerProcessRequestMethodFromCacheByMessageTypeEnd(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart;

        public static void FireInvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart != null)
            {
                InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart(processPipeline,
                    EventArgs.Empty);
            }
        }

        public static event EventHandler InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd;

        public static void FireInvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd != null)
            {
                InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd(processPipeline,
                    EventArgs.Empty);
            }
        }

        // TODO
        // go to db here

        public static event EventHandler ExecuteDataBaseProcessStart;

        public static void FireExecuteDataBaseProcessStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ExecuteDataBaseProcessStart != null)
            {
                ExecuteDataBaseProcessStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler ExecuteDataBaseProcessEnd;

        public static void FireExecuteDataBaseProcessEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ExecuteDataBaseProcessEnd != null)
            {
                ExecuteDataBaseProcessEnd(processPipeline, EventArgs.Empty);
            }
        }

        // TODO
        // go to db here


        public static event EventHandler SetDefaultValueStart;

        public static void FireSetDefaultValueStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (SetDefaultValueStart != null)
            {
                SetDefaultValueStart(processPipeline, EventArgs.Empty);
            }
        }

        public static event EventHandler SetDefaultValueEnd;

        public static void FireSetDefaultValueEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (SetDefaultValueEnd != null)
            {
                SetDefaultValueEnd(processPipeline, EventArgs.Empty);
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
