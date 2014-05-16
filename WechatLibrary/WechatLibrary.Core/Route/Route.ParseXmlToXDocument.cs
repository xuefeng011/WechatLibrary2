using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WechatLibrary.Core.Route
{
    public partial class Route
    {
        public void ParseXmlToXDocument()
        {
            this.RequestXDocument = XDocument.Parse(this.RequestXml);
        }
    }
}
