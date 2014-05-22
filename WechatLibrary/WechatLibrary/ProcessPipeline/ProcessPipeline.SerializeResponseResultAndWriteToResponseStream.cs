using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 序列化响应消息到 xml 并写入到响应流。
        /// </summary>
        /// <returns>是否成功执行。</returns>
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
