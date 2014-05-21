using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public HttpContext Context
        {
            get;
            set;
        }

        public ProcessPipeline(HttpContext context)
        {
        }

        /// <summary>
        /// 开始处理管道事件。
        /// </summary>
        public void Start()
        {
        }
    }
}
