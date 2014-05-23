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
        /// 填充默认缺失信息。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool SetDefaultValue()
        {
            Wechat.FireSetDefaultValueStart(this);

            if (this.RequestMessage == null)
            {
                return false;
            }
            if (this.ResponseResult == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(this.ResponseResult.ToUserName) == true)
            {
                this.ResponseResult.ToUserName = this.RequestMessage.FromUserName;
            }
            if (string.IsNullOrEmpty(this.ResponseResult.FromUserName) == true)
            {
                this.ResponseResult.FromUserName = this.RequestMessage.ToUserName;
            }
            if (ResponseResult.CreateTime == default(int))
            {
                this.ResponseResult.CreateTime = (int)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            }

            Wechat.FireSetDefaultValueEnd(this);
            return true;
        }
    }
}
