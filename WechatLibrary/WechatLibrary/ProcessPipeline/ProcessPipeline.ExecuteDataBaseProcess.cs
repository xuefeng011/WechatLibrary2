using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool ExecuteDataBaseProcess()
        {
            Wechat.FireExecuteDataBaseProcessStart(this);

            

            Wechat.FireExecuteDataBaseProcessEnd(this);
            return true;
        }
    }
}
