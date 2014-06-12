using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WechatLibrary.Model;
using WechatLibrary.Model.ResultLog;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 记录当前响应消息。
        /// </summary>
        /// <returns>是否成功执行。</returns>
        public bool LogResult()
        {
            Wechat.FireLogResultStart(this);

            if (this.ResponseResult == null)
            {
                return false;
            }

            using (var entities = new WechatEntities())
            {
                var logQuery = entities.ReceiveLogs.Where(temp => temp.Id == this.LogId);
                var receiveLog = logQuery.FirstOrDefault();
                if (receiveLog != null)
                {
                    receiveLog.Result = new ResultLog()
                    {
                        Id = Guid.NewGuid(),
                        FromUserName = this.ResponseResult.FromUserName,
                        ToUserName = this.ResponseResult.ToUserName,
                        LogTime = DateTime.Now,
                        MsgType = this.ResponseResult.MsgType,
                        XmlSource = this.ResponseResult.Serialize()
                    };
                    entities.SaveChanges();
                }
                else
                {
                    return false;
                }
            }

            Wechat.FireLogResultEnd(this);
            return true;
        }
    }
}
