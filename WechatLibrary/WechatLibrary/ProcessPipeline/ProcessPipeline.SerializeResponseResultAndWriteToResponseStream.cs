using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool SerializeResponseResultAndWriteToResponseStream()
        {
            Wechat.FireSerializeResponseResultAndWriteToResponseStreamStart(this);

            if (this.HttpResponse != null)
            {
                string xml = this.ResponseResult == null ? string.Empty : ResponseResult.Serialize();
                this.HttpResponse.ContentType = "text/xml";
                this.HttpResponse.Write(xml);
                this.HttpResponse.End();
            }

            Wechat.FireSerializeResponseResultAndWriteToResponseStreamEnd(this);
            return true;
        }
    }
}
