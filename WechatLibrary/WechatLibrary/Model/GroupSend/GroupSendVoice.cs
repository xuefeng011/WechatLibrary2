using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization.Json;

namespace WechatLibrary.Model.GroupSend
{
    public class GroupSendVoice : IGroupSend
    {
        private List<string> _touser;

        [Json(Name = "touser")]
        public List<string> ToUser
        {
            get
            {
                _touser = _touser ?? new List<string>();
                return _touser;
            }
            set
            {
                _touser = value;
            }
        }

        [Json(Name = "msgtype")]
        public string MsgType
        {
            get
            {
                return "voice";
            }
        }

        private GroupSendVoiceMediaId _voice;

        [Json(Name = "voice")]
        public GroupSendVoiceMediaId Voice
        {
            get
            {
                _voice = _voice ?? new GroupSendVoiceMediaId();
                return _voice;
            }
            set
            {
                _voice = value;
            }
        }
    }

    public class GroupSendVoiceMediaId
    {
        [Json(Name = "media_id")]
        public string MediaId
        {
            get;
            set;
        }
    }
}
