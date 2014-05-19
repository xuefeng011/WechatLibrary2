using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 不回复消息。
    /// </summary>
    public class EmptyResult : ResponseResultBase
    {
        public override string Serialize()
        {
            return string.Empty;
        }
    }
}
