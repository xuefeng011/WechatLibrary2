using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Core.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 如果 Handler 的构造函数委托存在，则执行该 Handler。
        /// </summary>
        public void InvokeHandlerDelegateIfHandlerDelegateExist()
        {
            if (this.HandlerConstructorDelegate != null && this.HandlerProcessRequestMethod != null)
            {
                // 执行缓存的构造函数委托。
                object handlerInstance = this.HandlerConstructorDelegate.DynamicInvoke();

                // 是否使用数据库执行。
                bool dbProcess = false;

                // 创建参数数组。
                object[] parameters = new object[] { this.RequestMessage, dbProcess };

                // 执行 ProcessRequest 方法。
                this.ResponseResult = (ResponseResultBase)this.HandlerProcessRequestMethod.Invoke(handlerInstance, parameters);

                // 写回 ref 参数。
                this.DbProcess = (bool)parameters[1];
            }
            else
            {
                // 没有 Handler 则默认使用数据库执行。
                this.DbProcess = true;
            }
        }
    }
}
