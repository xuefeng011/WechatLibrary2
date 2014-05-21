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
        public bool ParseXmlToXDocument()
        {
            Wechat.FireParseXmlToXDocumentStart(this);

            try
            {
                this.RequestXDocument = XDocument.Parse(this.RequestXml);
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

            Wechat.FireParseXmlToXDocumentEnd(this);
            return true;
        }
    }
}
