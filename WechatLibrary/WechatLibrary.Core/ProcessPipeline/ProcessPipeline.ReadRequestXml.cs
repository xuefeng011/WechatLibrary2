using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Exception;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 从 Http 请求中获取消息 xml。
        /// </summary>
        public void ReadRequestXml()
        {
            if (this.HttpRequest != null)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(this.HttpRequest.InputStream))
                    {
#if DEBUG
                        this.RequestXml = @"<xml>
 <ToUserName><![CDATA[toUser]]></ToUserName>
 <FromUserName><![CDATA[fromUser]]></FromUserName> 
 <CreateTime>1348831860</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[this is a test]]></Content>
 <MsgId>1234567890123456</MsgId>
 </xml>";
                        return;
#endif
                        
                        this.RequestXml = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    throw new WechatProcessRequestException("从 Http 请求中读取消息 xml 失败！", ex);
                }
            }
        }
    }
}
