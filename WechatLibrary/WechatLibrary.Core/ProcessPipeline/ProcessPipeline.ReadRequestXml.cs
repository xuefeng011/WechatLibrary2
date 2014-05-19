using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 从 Http 请求中获取消息 xml。
        /// </summary>
        public void ReadRequestXml()
        {
            using (StreamReader sr = new StreamReader(this.HttpRequest.InputStream))
            {
                this.RequestXml = sr.ReadToEnd();
            }
        }
    }
}
