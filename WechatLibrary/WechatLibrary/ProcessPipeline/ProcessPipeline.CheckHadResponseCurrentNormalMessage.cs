using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 进行排重。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool CheckHadResponseCurrentNormalMessage()
        {
            Wechat.FireCheckHadResponseCurrentNormalMessageStart(this);

            if (this.RequestMessage is NormalMessageBase)
            {
                NormalMessageBase normalMessage = this.RequestMessage as NormalMessageBase;
                if (Cache.Cache.HadResponseNormalMessage(normalMessage.MsgId) == true)
                {
                    return false;
                }
                else
                {
                    Cache.Cache.AddHadResponseNormalMessageMsgId(normalMessage.MsgId);
                }
            }

            Wechat.FireCheckHadResponseCurrentNormalMessageEnd(this);
            return true;
        }
    }
}
