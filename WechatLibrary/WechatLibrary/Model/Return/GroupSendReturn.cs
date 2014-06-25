using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Model.Return
{
    public class GroupSendReturn : ReturnBase
    {
        /// <summary>
        /// 消息ID。
        /// </summary>
        public string MsgId
        {
            get;
            set;
        }
    }
}
