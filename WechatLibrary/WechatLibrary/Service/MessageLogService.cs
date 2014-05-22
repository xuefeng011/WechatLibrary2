using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WechatLibrary.Converter;
using WechatLibrary.Model;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.Service
{
    /// <summary>
    /// 消息记录服务。
    /// </summary>
    public partial class MessageLogService
    {
        /// <summary>
        /// 获取用户的上一条消息。
        /// </summary>
        /// <param name="message">当前消息。</param>
        /// <returns>如存在上一条消息，则返回上一条消息。不存在则返回 null。</returns>
        public static RequestMessageBase GetPrevMessage(RequestMessageBase message)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                // 获取当前消息对应的微信帐号。
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == message.ToUserName);
                if (wechatAccount == null)
                {
                    return null;
                }
                // 获取当前用户的记录消息并按时间倒序。
                var logs = wechatAccount.ReceiveLogs.Where(temp => temp.FromUserName == message.FromUserName).OrderByDescending(temp => temp.LogTime);
                if (logs.Count() >= 2)
                {
                    // 获取上一条的 xml 内容。
                    string xml = logs.ElementAt(1).XmlSource;
                    XDocument document;
                    try
                    {
                        document = XDocument.Parse(xml);
                    }
                    catch
                    {
                        return null;
                    }
                    var messageType = MessageTypeService.GetMessageTypeFromXDocument(document);
                    var prevMessage = XDocumentRequestMessageConverter.Deserialize(document, messageType);
                    return prevMessage;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取用户的上一条文本消息。
        /// </summary>
        /// <param name="message">当前消息。</param>
        /// <returns>如存在上一条文本消息，则返回上一条文本消息。不存在则返回 null。</returns>
        public static TextMessage GetPrevTextMessage(RequestMessageBase message)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                // 获取当前消息对应的微信帐号。
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == message.ToUserName);
                if (wechatAccount == null)
                {
                    return null;
                }
                // 获取当前用户的记录消息并按时间倒序。
                var logs = wechatAccount.ReceiveLogs.Where(temp => temp.FromUserName == message.FromUserName && temp.MsgType == RequestMessageType.Text.ToString()).OrderByDescending(temp => temp.LogTime);
                if (logs.Count() >= 2)
                {
                    // 获取上一条的 xml 内容。
                    string xml = logs.ElementAt(1).XmlSource;
                    XDocument document;
                    try
                    {
                        document = XDocument.Parse(xml);
                    }
                    catch
                    {
                        return null;
                    }
                    var prevMessage = XDocumentRequestMessageConverter.Deserialize<TextMessage>(document);
                    return prevMessage;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取用户的上一条文本消息内容。
        /// </summary>
        /// <param name="message">当前消息。</param>
        /// <returns>如存在上一条文本消息，则返回上一条文本消息的内容，不存在则返回 null。</returns>
        public static string GetPrevTextMessageContent(RequestMessageBase message)
        {
            return GetPrevTextMessageContent(message.FromUserName, message.ToUserName);
        }

        /// <summary>
        /// 获取用户的上一条文本消息内容。
        /// </summary>
        /// <param name="fromUserName">当前消息的微信用户 Id。</param>
        /// <param name="toUserName">当前消息的微信开发者 Id。</param>
        /// <returns>如存在上一条文本消息，则返回上一条文本消息的内容，不存在则返回 null。</returns>
        public static string GetPrevTextMessageContent(string fromUserName, string toUserName)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                // 获取当前消息对应的微信帐号。
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == toUserName);
                if (wechatAccount == null)
                {
                    return null;
                }
                // 获取当前用户的记录消息并按时间倒序。
                var logs = wechatAccount.ReceiveLogs.Where(temp => temp.FromUserName == fromUserName && temp.MsgType == RequestMessageType.Text.ToString()).OrderByDescending(temp => temp.LogTime);
                if (logs.Count() >= 2)
                {
                    // 获取上一条的 xml 内容。
                    string content = logs.ElementAt(1).Content;
                    return content;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取用户的上一条图片消息。
        /// </summary>
        /// <param name="message">当前消息。</param>
        /// <returns>如存在上一条图片消息，则返回上一条图片消息。不存在则返回 null。</returns>
        public static ImageMessage GetPrevImageMessage(RequestMessageBase message)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                // 获取当前消息对应的微信帐号。
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == message.ToUserName);
                if (wechatAccount == null)
                {
                    return null;
                }
                // 获取当前用户的记录消息并按时间倒序。
                var logs = wechatAccount.ReceiveLogs.Where(temp => temp.FromUserName == message.FromUserName && temp.MsgType == RequestMessageType.Image.ToString()).OrderByDescending(temp => temp.LogTime);
                if (logs.Count() >= 2)
                {
                    // 获取上一条的 xml 内容。
                    string xml = logs.ElementAt(1).XmlSource;
                    XDocument document;
                    try
                    {
                        document = XDocument.Parse(xml);
                    }
                    catch
                    {
                        return null;
                    }
                    var prevMessage = XDocumentRequestMessageConverter.Deserialize<ImageMessage>(document);
                    return prevMessage;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
