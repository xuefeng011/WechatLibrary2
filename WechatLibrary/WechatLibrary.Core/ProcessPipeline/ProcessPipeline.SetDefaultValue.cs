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
        /// 填充默认缺失信息。
        /// </summary>
        public void SetDefaultValue()
        {
            if (this.RequestMessage == null)
            {
                return;
            }
            if (this.ResponseResult == null)
            {
                return;
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
        }
    }
}
