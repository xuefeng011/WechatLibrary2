using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool ReadRequestXml()
        {
            Wechat.FireGetHttpRequestAndHttpResponseStart(this);

            try
            {
                using (StreamReader sr = new StreamReader(this.HttpRequest.InputStream))
                {
#if DEBUG
                    this.RequestXml = @"<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>1348831860</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[this is a test]]></Content><MsgId>1234567890123456</MsgId></xml>";
#else
                    this.RequestXml = sr.ReadToEnd();
#endif
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            Wechat.FireReadRequestXmlEnd(this);
            return true;
        }
    }
}
