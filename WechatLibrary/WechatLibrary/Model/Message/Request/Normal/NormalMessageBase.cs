using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request.Normal
{
    /// <summary>
    /// 普通消息基类。
    /// </summary>
    public abstract class NormalMessageBase : RequestMessageBase
    {
        private long _msgId;

        /// <summary>
        /// 消息 id，64位 整型。
        /// </summary>
        public long MsgId
        {
            get
            {
                return _msgId;
            }
            set
            {
                _msgId = value;
            }
        }
    }
}
