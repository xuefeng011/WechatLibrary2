using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.Route
{
    public partial class Route
    {
        public void ReadRequestXml()
        {
            using (StreamReader sr = new StreamReader(this.HttpRequest.InputStream))
            {
                this.RequestXml = sr.ReadToEnd();
            }
        }
    }
}
