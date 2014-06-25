using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Model.GroupSend;

namespace WechatLibrary.Service.GroupSendService
{
    public partial class GroupSendService
    {
        public static GroupSendVoice ToGroupSend(VoiceAutoResponseResult voiceResult, List<string> userList)
        {
            return new GroupSendVoice()
            {
                ToUser = userList,
                Voice = new GroupSendVoiceMediaId()
                {
                    MediaId = voiceResult.WechatResource.MediaId
                }
            };
        }
    }
}
