using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 转换消息 xml 到 XDocument。
        /// </summary>
        public void ParseXmlToXDocument()
        {
            this.RequestXDocument = XDocument.Parse(this.RequestXml);
        }
    }
}
