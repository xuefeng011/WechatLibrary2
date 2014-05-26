using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.UserManagement
{
    /// <summary>
    /// 获取用户信息时国家地区的语言版本。
    /// </summary>
    public enum UserInfoLanguage
    {
        /// <summary>
        /// 简体。
        /// </summary>
        ZhCn,

        /// <summary>
        /// 繁体。
        /// </summary>
        ZhTw,

        /// <summary>
        /// 英语。
        /// </summary>
        En
    }

    internal static class UserInfoLanguageExtension
    {
        internal static string GetValue(this UserInfoLanguage userInfoLanguage)
        {
            switch (userInfoLanguage)
            {
                case UserInfoLanguage.ZhCn:
                    {
                        return "zh_CN";
                    }
                case UserInfoLanguage.ZhTw:
                    {
                        return "zh_TW";
                    }
                case UserInfoLanguage.En:
                    {
                        return "en";
                    }
                default:
                    {
                        throw new ArgumentException("语言版本错误！", "userInfoLanguage");
                    }
            }
        }
    }
}
