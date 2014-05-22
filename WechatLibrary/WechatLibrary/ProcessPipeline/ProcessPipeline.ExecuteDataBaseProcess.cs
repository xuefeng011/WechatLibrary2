using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Request;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 执行数据库自动回复。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool ExecuteDataBaseProcess()
        {
            if (DbProcess == true)
            {
                Wechat.FireExecuteDataBaseProcessStart(this);

                switch (this.RequestMessageType)
                {
                    case RequestMessageType.Text:
                        {
                            if (this.ExecuteTextMessageDataBaseProcess() == false)
                            {
                                return false;
                            }
                            break;
                        }
                    case RequestMessageType.Image:
                        {
                            if (this.ExecuteImageMessageDataBaseProcess() == false)
                            {
                                return false;
                            }
                            break;
                        }
                    case RequestMessageType.Voice:
                        {
                            if (this.ExecuteVoiceMessageDataBaseProcess() == false)
                            {
                                return false;
                            }
                            break;
                        }
                    case RequestMessageType.Video:
                    case RequestMessageType.Location:
                    case RequestMessageType.Link:
                    case RequestMessageType.Subscribe:
                    case RequestMessageType.QRSubscribe:
                    case RequestMessageType.Unsubscribe:
                    case RequestMessageType.QRScan:
                    case RequestMessageType.MenuButtonClick:
                    case RequestMessageType.MenuButtonView:
                    default:
                        {
                            return false;
                        }
                }

                Wechat.FireExecuteDataBaseProcessEnd(this);
            }
            return true;
        }
    }
}
