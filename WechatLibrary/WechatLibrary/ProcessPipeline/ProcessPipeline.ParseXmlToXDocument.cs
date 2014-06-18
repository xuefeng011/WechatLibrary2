using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 转换消息 xml 到消息 XDocument。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool ParseXmlToXDocument()
        {
            Wechat.FireParseXmlToXDocumentStart(this);

            try
            {
                this.RequestXDocument = XDocument.Parse(this.RequestXml);
            }
            catch (Exception)
            {
                return false;
            }

            Wechat.FireParseXmlToXDocumentEnd(this);
            return true;
        }
    }
}
