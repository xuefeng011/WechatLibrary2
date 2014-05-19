using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 将回复消息序列化并写入 Http 响应流中。
        /// </summary>
        public void SerializeResponseResultAndWriteToResponseStream()
        {
            if (this.HttpResponse != null)
            {
                string xml = ResponseResult == null ? string.Empty : ResponseResult.Serialize();
                this.HttpResponse.ContentType = "text/xml";
                this.HttpResponse.Write(xml);
                this.HttpResponse.End();
            }
        }
    }
}
