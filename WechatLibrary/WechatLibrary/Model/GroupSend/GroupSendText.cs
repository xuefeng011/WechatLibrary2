using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization.Json;

namespace WechatLibrary.Model.GroupSend
{
    public class GroupSendText:IGroupSend
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
                return "text";
            }
        }

        private GroupSendTextContent _text;

        [Json(Name = "text")]
        public GroupSendTextContent Text
        {
            get
            {
                _text = _text ?? new GroupSendTextContent();
                return _text;
            }
            set
            {
                _text = value;
            }
        }
    }

    public class GroupSendTextContent
    {
        [Json(Name = "content")]
        public string Content
        {
            get;
            set;
        }
    }
}
