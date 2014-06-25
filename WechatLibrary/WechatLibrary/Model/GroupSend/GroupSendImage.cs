using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization.Json;

namespace WechatLibrary.Model.GroupSend
{
    public class GroupSendImage:IGroupSend
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
                return "image";
            }
        }

        private GroupSendImageMediaId _image;

        [Json(Name = "image")]
        public GroupSendImageMediaId Image
        {
            get
            {
                _image = _image ?? new GroupSendImageMediaId();
                return _image;
            }
            set
            {
                _image = value;
            }
        }
    }

    public class GroupSendImageMediaId
    {
        [Json(Name = "media_id")]
        public string MediaId
        {
            get;
            set;
        }
    }
}
