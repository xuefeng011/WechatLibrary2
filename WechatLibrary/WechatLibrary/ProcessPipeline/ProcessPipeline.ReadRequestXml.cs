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
                    this.RequestXml = sr.ReadToEnd();
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
