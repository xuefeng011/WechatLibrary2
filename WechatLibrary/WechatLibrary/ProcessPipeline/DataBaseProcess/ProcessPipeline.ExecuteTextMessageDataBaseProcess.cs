using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Converter;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse;
using WechatLibrary.Model.Message.Request.Normal;
using WechatLibrary.Service;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        public bool ExecuteTextMessageDataBaseProcess()
        {
            var textMessage = this.RequestMessage as TextMessage;
            if (textMessage == null)
            {
                return false;
            }
            using (WechatEntities entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.AppId == this.RequestMessage.ToUserName);
                if (wechatAccount == null)
                {
                    return false;
                }
                var textMessageMatches = wechatAccount.TextMessageMatches.AsEnumerable();
                var textMessageEqualsMatches = textMessageMatches.Where(temp => temp.MatchOption == "equals");
                foreach (var textMessageEqualsMatch in textMessageEqualsMatches)
                {
                    if (textMessageEqualsMatch.IsMatch(textMessage) == true)
                    {
                        this.ResponseResult = AutoResponseResultConverter.ConvertTo(MatchResultMapping.GetMapping(textMessageEqualsMatch));
                        return true;
                    }
                }
                var textMessageEqualsIgnoreMatches = textMessageEqualsMatches.Where(temp => temp.MatchOption == "equalsignore");
                foreach (var textMessageEqualsIgnoreMatch in textMessageEqualsIgnoreMatches)
                {
                    if (textMessageEqualsIgnoreMatch.IsMatch(textMessage) == true)
                    {
                        this.ResponseResult = AutoResponseResultConverter.ConvertTo(MatchResultMapping.GetMapping(textMessageEqualsIgnoreMatch));
                        return true;
                    }
                }
                var textMessageContainsMatches =
                    textMessageEqualsMatches.Where(temp => temp.MatchOption == "contains")
                        .OrderBy(temp => temp.MatchLevel);
                foreach (var textMessageContainsMatch in textMessageContainsMatches)
                {
                    if (textMessageContainsMatch.IsMatch(textMessage) == true)
                    {
                        this.ResponseResult = AutoResponseResultConverter.ConvertTo(MatchResultMapping.GetMapping(textMessageContainsMatch));
                        return true;
                    }
                }
                var textMessageContainsIgnoreMatches =
                    textMessageContainsMatches.Where(temp => temp.MatchOption == "containsignore")
                        .OrderBy(temp => temp.MatchLevel);
                foreach (var textMessageContainsIgnoreMatch in textMessageContainsIgnoreMatches)
                {
                    if (textMessageContainsIgnoreMatch.IsMatch(textMessage) == true)
                    {
                        this.ResponseResult = AutoResponseResultConverter.ConvertTo(MatchResultMapping.GetMapping(textMessageContainsIgnoreMatch));
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
