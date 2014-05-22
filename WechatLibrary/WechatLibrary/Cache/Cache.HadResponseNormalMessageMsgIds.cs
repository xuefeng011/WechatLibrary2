using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WechatLibrary.Cache
{
    public partial class Cache
    {
        private static readonly HashSet<long> HadResponseNormalMessageMsgIds = new HashSet<long>();

        public static bool AddHadResponseNormalMessageMsgId(long msgId)
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
                    HadResponseNormalMessageMsgIds.Remove(msgId);
                }
            });
            return true;
        }

        public static bool HadResponseNormalMessage(long msgId)
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
