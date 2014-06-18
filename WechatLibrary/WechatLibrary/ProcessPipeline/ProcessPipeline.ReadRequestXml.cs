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
        /// <summary>
        /// 从请求流中读取消息 xml。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool ReadRequestXml()
        {
            Wechat.FireGetHttpRequestAndHttpResponseStart(this);

            try
            {
                using (StreamReader sr = new StreamReader(this.HttpRequest.InputStream))
                {
#if DEBUG
                    Random rand = new Random();
                    this.RequestXml = @"<xml><ToUserName><![CDATA[gh_5728cc2d22a6]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>1348831860</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + "random content" + rand.Next(100000) + "]]></Content><MsgId>" + rand.Next(100000) + "</MsgId></xml>";
#else
                    this.RequestXml = sr.ReadToEnd();
#endif
                }
            }
            catch (Exception)
            {
                return false;
            }

            Wechat.FireReadRequestXmlEnd(this);
            return true;
        }
    }
}
