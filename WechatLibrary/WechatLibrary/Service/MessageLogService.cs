using System;
using System.Collections.Generic;
using System.Linq;
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
        /// 当前用户的上一条消息。
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
    }
}
