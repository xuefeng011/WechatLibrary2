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
        /// 如果 Handler 的构造函数委托存在，则执行该 Handler。
        /// </summary>
        public void InvokeHandlerDelegateIfHandlerDelegateExist()
        {
            if (this.HandlerDelegate != null)
            {
                // 执行缓存的构造函数。
                dynamic handlerInstance = this.HandlerDelegate.DynamicInvoke();

                // 是否使用数据库执行。
                bool dbProcess = false;

                // 执行 Handler 的 ProcessRequest 方法。
                this.ResponseResult = handlerInstance.ProcessRequest(this.RequestMessage, ref dbProcess);

                // 设置回是否由数据库执行。
                this.DbProcess = dbProcess;
            }
        }
    }
}
