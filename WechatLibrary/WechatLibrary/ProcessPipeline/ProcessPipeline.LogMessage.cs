using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;
using WechatLibrary.Model.Message.Request.Normal;
using WechatLibrary.Model.ReveiceLog;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool LogMessage()
        {
            Wechat.FireLogMessageStart(this);

            using (WechatEntities entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == this.RequestMessage.ToUserName);
                if (wechatAccount == null)
                {
                    return false;
                }
                ReceiveLog log = new ReceiveLog();
                if (this.RequestMessage is TextMessage)
                {
                    log.Content = (this.RequestMessage as TextMessage).Content;
                }
                log.FromUserName = this.RequestMessage.FromUserName;
                log.ToUserName = this.RequestMessage.ToUserName;
                log.MsgType = this.RequestMessageType.ToString();
                log.XmlSource = this.RequestXml;
                log.LogTime = DateTime.Now;

                wechatAccount.ReceiveLogs.Add(log);
                entities.SaveChanges();
            }

            Wechat.FireLogMessageEnd(this);
            return true;
        }
    }
}
