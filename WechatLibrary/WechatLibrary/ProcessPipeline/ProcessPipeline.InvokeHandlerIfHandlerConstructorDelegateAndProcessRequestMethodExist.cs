using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 执行 Handler。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool InvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExist()
        {
            Wechat.FireInvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistStart(this);

            if (this.DbProcess == false && this.HandlerConstructorDelegate != null && this.HandlerProcessRequestMethod != null)
            {
                try
                {
                    // 执行缓存的无参构造函数委托。
                    object handlerInstance = this.HandlerConstructorDelegate.DynamicInvoke();

                    // 是否使用数据库执行。
                    bool dbProcess = false;

                    // 创建参数数组。
                    object[] parameters = new object[2] { this.RequestMessage, dbProcess };

                    // 执行 ProcessRequest 方法。
                    this.ResponseResult = this.HandlerProcessRequestMethod.Invoke(handlerInstance, parameters) as ResponseResultBase;

                    // 写回 ref 参数。
                    this.DbProcess = (bool)parameters[1];
                }
                catch (Exception)
                {
                    return false;
                }
            }

            Wechat.FireInvokeHandlerIfHandlerConstructorDelegateAndProcessRequestMethodExistEnd(this);
            return true;
        }
    }
}
