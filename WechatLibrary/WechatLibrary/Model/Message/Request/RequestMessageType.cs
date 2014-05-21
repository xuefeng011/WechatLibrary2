using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Request
{
    public enum RequestMessageType
    {
        Text,
        Image,
        Voice,
        Video,
        Location,
        Link,
        Subscribe,
        QRSubscribe,
        Unsubscribe,
        QRScan,
        UploadLocation,
        MenuButtonClick,
        MenuButtonView,
    }
}
