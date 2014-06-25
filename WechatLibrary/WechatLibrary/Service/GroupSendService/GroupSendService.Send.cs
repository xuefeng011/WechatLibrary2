using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization.Json;
using Common.Web;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Service.GroupSendService
{
    public partial class GroupSendService
    {
        private const string GroupSendTemplate =
            "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}";

        public static bool Send(TextAutoResponseResult textResult, string wechatId)
        {
            using (var entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
                if (wechatAccount == null) return false;

                var userList = UserManagementService.UserManagementService.GetUserList(wechatAccount);

                var groupSend = ToGroupSend(textResult, userList as List<string>);

                string url = string.Format(GroupSendTemplate, wechatAccount.AccessToken.Value);

                var json = CustomerServiceMessageService.HttpPost(url, JsonHelper.SerializeToJson(groupSend));

                GroupSendReturn groupSendReturn = JsonHelper.Deserialize<GroupSendReturn>(json);

                return groupSendReturn.ErrorCode == 0;
            }
        }

        public static bool Send(ImageAutoResponseResult imageResult, string wechatId)
        {
            using (var entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
                if (wechatAccount == null) return false;

                var userList = UserManagementService.UserManagementService.GetUserList(wechatAccount);

                var groupSend = ToGroupSend(imageResult, userList as List<string>);

                string url = string.Format(GroupSendTemplate, wechatAccount.AccessToken.Value);

                var json = CustomerServiceMessageService.HttpPost(url, JsonHelper.SerializeToJson(groupSend));

                GroupSendReturn groupSendReturn = JsonHelper.Deserialize<GroupSendReturn>(json);

                return groupSendReturn.ErrorCode == 0;
            }
        }

        public static bool Send(VoiceAutoResponseResult voiceResult, string wechatId)
        {
            using (var entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
                if (wechatAccount == null) return false;

                var userList = UserManagementService.UserManagementService.GetUserList(wechatAccount);

                var groupSend = ToGroupSend(voiceResult, userList as List<string>);

                string url = string.Format(GroupSendTemplate, wechatAccount.AccessToken.Value);

                var json = CustomerServiceMessageService.HttpPost(url, JsonHelper.SerializeToJson(groupSend));

                GroupSendReturn groupSendReturn = JsonHelper.Deserialize<GroupSendReturn>(json);

                return groupSendReturn.ErrorCode == 0;
            }
        }

        public static bool Send(NewsAutoResponseResult newsResult, string wechatId)
        {
            using (var entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == wechatId);
                if (wechatAccount == null) return false;

                var userList = UserManagementService.UserManagementService.GetUserList(wechatAccount);

                var groupSend = ToGroupSend(newsResult, userList as List<string>, wechatAccount);

                string url = string.Format(GroupSendTemplate, wechatAccount.AccessToken.Value);

                var sendJson = JsonHelper.SerializeToJson(groupSend);

                var uploadNewsReturn = JsonHelper.Deserialize<NewsUploadReturn>(CustomerServiceMessageService.HttpPost(string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}",
                         wechatAccount.AccessToken.Value), sendJson));

                var toUser = userList.SerializeToJson();

                var sendJson2 = "{\"touser\":" + toUser + ",\"mpnews\":{\"media_id\":\"" + uploadNewsReturn.MediaId + "\"},\"msgtype\":\"mpnews\"}";

                var json = CustomerServiceMessageService.HttpPost(url, sendJson2);

                GroupSendReturn groupSendReturn = JsonHelper.Deserialize<GroupSendReturn>(json);

                return groupSendReturn.ErrorCode == 0;
            }
        }
    }
}
