using System;

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
        internal static void FireGetHttpRequestAndHttpResponseStart(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireGetHttpRequestAndHttpResponseEnd(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireReadRequestXmlStart(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireReadRequestXmlEnd(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireParseXmlToXDocumentStart(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireParseXmlToXDocumentEnd(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireGetMessageTypeFromXDocumentStart(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireGetMessageTypeFromXDocumentEnd(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireDeserializeXDocumentByMessageTypeStart(ProcessPipeline.ProcessPipeline processPipeline)
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
        internal static void FireDeserializeXDocumentByMessageTypeEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (DeserializeXDocumentByMessageTypeEnd != null)
            {
                DeserializeXDocumentByMessageTypeEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始根据普通消息的 MsgId 排重。
        /// </summary>
        public static event EventHandler CheckHadResponseCurrentNormalMessageStart;

        /// <summary>
        /// 触发开始根据普通消息的 MsgId 排重事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireCheckHadResponseCurrentNormalMessageStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (CheckHadResponseCurrentNormalMessageStart != null)
            {
                CheckHadResponseCurrentNormalMessageStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束根据普通消息的 MsgId 排重。
        /// </summary>
        public static event EventHandler CheckHadResponseCurrentNormalMessageEnd;

        /// <summary>
        /// 触发结束根据普通消息的 MsgId 排重。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireCheckHadResponseCurrentNormalMessageEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (CheckHadResponseCurrentNormalMessageEnd != null)
            {
                CheckHadResponseCurrentNormalMessageEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始记录用户消息。
        /// </summary>
        public static event EventHandler LogMessageStart;

        /// <summary>
        /// 触发开始记录用户消息事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireLogMessageStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (LogMessageStart != null)
            {
                LogMessageStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束记录用户消息。
        /// </summary>
        public static event EventHandler LogMessageEnd;

        /// <summary>
        /// 结束记录用户消息事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireLogMessageEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (LogMessageEnd != null)
            {
                LogMessageEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始根据消息类型从缓存中获取处理类的构造函数委托。
        /// </summary>
        public static event EventHandler GetHandlerConstructorDelegateFromCacheByMessageTypeStart;

        /// <summary>
        /// 触发开始根据消息类型从缓存中获取处理类的构造函数委托事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireGetHandlerConstructorDelegateFromCacheByMessageTypeStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHandlerConstructorDelegateFromCacheByMessageTypeStart != null)
            {
                GetHandlerConstructorDelegateFromCacheByMessageTypeStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束根据消息类型从缓存中获取处理类的构造函数委托。
        /// </summary>
        public static event EventHandler GetHandlerConstructorDelegateFromCacheByMessageTypeEnd;

        /// <summary>
        /// 触发结束根据消息类型从缓存中获取处理类的构造函数委托事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireGetHandlerConstructorDelegateFromCacheByMessageTypeEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHandlerConstructorDelegateFromCacheByMessageTypeEnd != null)
            {
                GetHandlerConstructorDelegateFromCacheByMessageTypeEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始根据消息类型从缓存中获取处理类的 ProcessRequest 方法。
        /// </summary>
        public static event EventHandler GetHandlerProcessRequestMethodFromCacheByMessageTypeStart;

        /// <summary>
        /// 触发开始根据消息类型从缓存中获去处理类的 ProcessRequest 方法事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireGetHandlerProcessRequestMethodFromCacheByMessageTypeStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHandlerProcessRequestMethodFromCacheByMessageTypeStart != null)
            {
                GetHandlerProcessRequestMethodFromCacheByMessageTypeStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束根据消息类型从缓存中获取处理类的 ProcessRequest 方法。
        /// </summary>
        public static event EventHandler GetHandlerProcessRequestMethodFromCacheByMessageTypeEnd;

        /// <summary>
        /// 触发结束根据消息类型从缓存中获取处理类的 ProcessRequest 方法。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireGetHandlerProcessRequestMethodFromCacheByMessageTypeEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (GetHandlerProcessRequestMethodFromCacheByMessageTypeEnd != null)
            {
                GetHandlerProcessRequestMethodFromCacheByMessageTypeEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始执行处理类。
        /// </summary>
        public static event EventHandler InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart;

        /// <summary>
        /// 触发开始执行处理类事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireInvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart != null)
            {
                InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart(processPipeline,
                    EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束执行处理类。
        /// </summary>
        public static event EventHandler InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd;

        /// <summary>
        /// 触发结束执行处理类事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireInvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd != null)
            {
                InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd(processPipeline,
                    EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始执行数据库处理。
        /// </summary>
        public static event EventHandler ExecuteDataBaseProcessStart;

        /// <summary>
        /// 触发开始执行数据库处理事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireExecuteDataBaseProcessStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ExecuteDataBaseProcessStart != null)
            {
                ExecuteDataBaseProcessStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始执行数据库处理文本消息。
        /// </summary>
        public static event EventHandler ExecuteTextMessageDataBaseProcessStart;

        /// <summary>
        /// 触发开始执行数据库处理文本消息事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireExecuteTextMessageDataBaseProcessStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ExecuteTextMessageDataBaseProcessStart != null)
            {
                ExecuteTextMessageDataBaseProcessStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束执行数据库处理文本消息。
        /// </summary>
        public static event EventHandler ExecuteTextMessageDataBaseProcessEnd;

        /// <summary>
        /// 触发结束执行数据库处理文本消息事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireExecuteTextMessageDataBaseProcessEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ExecuteTextMessageDataBaseProcessEnd != null)
            {
                ExecuteTextMessageDataBaseProcessEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束执行数据库处理。
        /// </summary>
        public static event EventHandler ExecuteDataBaseProcessEnd;

        /// <summary>
        /// 触发结束执行数据库处理事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireExecuteDataBaseProcessEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (ExecuteDataBaseProcessEnd != null)
            {
                ExecuteDataBaseProcessEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始设置默认缺失参数。
        /// </summary>
        public static event EventHandler SetDefaultValueStart;

        /// <summary>
        /// 触发开始设置默认缺失参数事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireSetDefaultValueStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (SetDefaultValueStart != null)
            {
                SetDefaultValueStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束设置默认缺失参数。
        /// </summary>
        public static event EventHandler SetDefaultValueEnd;

        /// <summary>
        /// 触发结束设置默认缺失参数事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireSetDefaultValueEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (SetDefaultValueEnd != null)
            {
                SetDefaultValueEnd(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始序列化消息到 xml 并写入到响应流。
        /// </summary>
        public static event EventHandler SerializeResponseResultAndWriteToResponseStreamStart;

        /// <summary>
        /// 触发开始序列化消息到 xml 并写入到响应流事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireSerializeResponseResultAndWriteToResponseStreamStart(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (SerializeResponseResultAndWriteToResponseStreamStart != null)
            {
                SerializeResponseResultAndWriteToResponseStreamStart(processPipeline, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 结束序列化消息到 xml 并写入到响应流。
        /// </summary>
        public static event EventHandler SerializeResponseResultAndWriteToResponseStreamEnd;

        /// <summary>
        /// 触发结束序列化消息到 xml 并写入到响应流事件。
        /// </summary>
        /// <param name="processPipeline">触发事件所在处理管道。</param>
        internal static void FireSerializeResponseResultAndWriteToResponseStreamEnd(ProcessPipeline.ProcessPipeline processPipeline)
        {
            if (SerializeResponseResultAndWriteToResponseStreamEnd != null)
            {
                SerializeResponseResultAndWriteToResponseStreamEnd(processPipeline, EventArgs.Empty);
            }
        }
    }
}
