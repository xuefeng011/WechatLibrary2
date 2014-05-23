using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Converter;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse;
using WechatLibrary.Model.Message.Request.Event;

namespace WechatLibrary.ProcessPipeline
{
    public partial class ProcessPipeline
    {
        /// <summary>
        /// 执行数据库自定义菜单点击事件的自动回复。
        /// </summary>
        /// <returns>是否执行成功。</returns>
        public bool ExecuteMenuButtonClickMessageDataBaseProcess()
        {
            Wechat.FireExecuteMenuButtonClickMessageDataBaseProcessStart(this);

            var menuButtonClickMessage = this.RequestMessage as MenuButtonClickMessage;
            if (menuButtonClickMessage == null)
            {
                return false;
            }
            using (WechatEntities entities = new WechatEntities())
            {
                var wechatAccount = entities.WechatAccounts.FirstOrDefault(temp => temp.WechatId == this.RequestMessage.ToUserName);
                if (wechatAccount == null)
                {
                    return false;
                }
                var menu = wechatAccount.Menu;
                if (menu == null)
                {
                    return false;
                }
                var buttons = menu.Buttons;
                if (buttons == null || buttons.Count == 0)
                {
                    return false;
                }
                foreach (var button in buttons)
                {
                    if (button.Type == Model.Menu.MenuButtonType.Click && button.Key == menuButtonClickMessage.EventKey && button.MatchResultMapping != null)
                    {
                        this.ResponseResult = AutoResponseResultConverter.ConvertTo(MatchResultMapping.GetMapping(button.MatchResultMapping.ResultType, button.MatchResultMapping.ResultId));
                        return true;
                    }
                    else
                    {
                        if (button.SubButtons == null)
                        {
                            continue;
                        }
                        foreach (var subButton in button.SubButtons)
                        {
                            if (subButton.Type == Model.Menu.MenuButtonType.Click && subButton.Key == menuButtonClickMessage.EventKey && subButton.MatchResultMapping != null)
                            {
                                this.ResponseResult = AutoResponseResultConverter.ConvertTo(MatchResultMapping.GetMapping(subButton.MatchResultMapping.ResultType, subButton.MatchResultMapping.ResultId));
                                return true;
                            }
                        }
                    }
                }
            }

            Wechat.FireExecuteMenuButtonClickMessageDataBaseProcessEnd(this);
            return false;
        }
    }
}
