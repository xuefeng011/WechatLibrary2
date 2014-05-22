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
                    case RequestMessageType.Voice:
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
