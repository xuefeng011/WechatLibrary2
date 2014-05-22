using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WechatLibrary.Cache
{
    internal partial class Cache
    {
        private static readonly HashSet<long> HadResponseNormalMessageMsgIds = new HashSet<long>();

        /// <summary>
        /// 添加普通消息 Id 到记录中。
        /// </summary>
        /// <param name="msgId">普通消息 Id。</param>
        /// <returns>是否成功添加。</returns>
        internal static bool AddHadResponseNormalMessageMsgId(long msgId)
        {
            lock (HadResponseNormalMessageMsgIds)
            {
                if (HadResponseNormalMessageMsgIds.Contains(msgId) == true)
                {
                    return false;
                }
                else
                {
                    HadResponseNormalMessageMsgIds.Add(msgId);
                }
            }
            Task.Factory.StartNew(() =>
            {
                // 等待一分钟。
                Thread.Sleep(1000 * 60);
                lock (HadResponseNormalMessageMsgIds)
                {
                    // 移除记录的普通消息 Id。
                    HadResponseNormalMessageMsgIds.Remove(msgId);
                }
            });
            return true;
        }

        /// <summary>
        /// 记录中是否存在普通消息 Id。
        /// </summary>
        /// <param name="msgId">普通消息 Id。</param>
        /// <returns>记录中是否存在。</returns>
        internal static bool HadResponseNormalMessage(long msgId)
        {
            lock (HadResponseNormalMessageMsgIds)
            {
                if (HadResponseNormalMessageMsgIds.Contains(msgId) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
