using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WechatLibrary.Model.Exception;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 转换消息 xml 到 XDocument。
        /// </summary>
        public void ParseXmlToXDocument()
        {
            if (string.IsNullOrEmpty(this.RequestXml) == false)
            {
                try
                {
                    this.RequestXDocument = XDocument.Parse(this.RequestXml);
                }
                catch (Exception ex)
                {
                    throw new WechatProcessRequestException("转化消息 xml 到 XDocument 失败！", ex);
                }
            }
        }
    }
}
