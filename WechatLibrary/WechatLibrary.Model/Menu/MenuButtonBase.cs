using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Menu
{
    public abstract class MenuButtonBase
    {
        /// <summary>
        /// 菜单的响应动作类型，目前有 click、view 两种类型。
        /// </summary>
        [Json(Name = "type", Converter = typeof(MenuButtonTypeConverter))]
        public MenuButtonType Type
        {
            get;
            set;
        }

        /// <summary>
        /// 菜单标题，不超过 16 个字节，子菜单不超过 40 个字节。
        /// </summary>
        [Json(Name = "name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// click 类型必须。菜单 KEY 值，用于消息接口推送，不超过 128 字节。
        /// </summary>
        [Json(Name = "key", IgnoreNull = true)]
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// view 类型必须。网页链接，用户点击菜单可打开链接，不超过 256 字节。
        /// </summary>
        [Json(Name = "url", IgnoreNull = true)]
        public string Url
        {
            get;
            set;
        }
    }
}
