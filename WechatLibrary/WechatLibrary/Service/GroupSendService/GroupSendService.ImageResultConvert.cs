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
        public static GroupSendImage ToGroupSend(ImageAutoResponseResult imageResult, List<string> userList)
        {
            return new GroupSendImage()
            {
                ToUser = userList,
                Image = new GroupSendImageMediaId()
                {
                    MediaId = imageResult.WechatResource.MediaId
                }
            };
        }
    }
}
