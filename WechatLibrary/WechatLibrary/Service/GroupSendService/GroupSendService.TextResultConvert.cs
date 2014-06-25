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
        public static GroupSendText ToGroupSend(TextAutoResponseResult textResult, List<string> userList)
        {
            return new GroupSendText()
            {
                ToUser = userList,
                Text = new GroupSendTextContent()
                {
                    Content = textResult.Content
                }
            };
        }
    }
}
