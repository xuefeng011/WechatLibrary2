using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using WechatLibrary.Model.Menu;

namespace WechatLibrary.Converter
{
    /// <summary>
    /// 微信菜单按钮类型自定义 Json 转换。
    /// </summary>
    internal partial class MenuButtonTypeConverter : JsonConverter
    {
        /// <summary>
        /// 反序列化 Json 字符串到微信菜单按钮类型。
        /// </summary>
        /// <param name="value">Json 字符串。</param>
        /// <param name="type">正在反序列化的类型。</param>
        /// <param name="skip">是否跳过该项的反序列化。</param>
        /// <returns>微信菜单按钮类型。</returns>
        public override object Deserialize(string value, Type type, ref bool skip)
        {
            if (value != null)
            {
                if (value.Equals("\"click\"", StringComparison.OrdinalIgnoreCase) == true)
                {
                    return MenuButtonType.Click;
                }
                else if (value.Equals("\"view\"", StringComparison.OrdinalIgnoreCase) == true)
                {
                    return MenuButtonType.View;
                }
                else
                {
                    return MenuButtonType.None;
                }
            }
            else
            {
                return MenuButtonType.None;
            }
        }

        /// <summary>
        /// 序列化微信菜单按钮类型到 Json 字符串。
        /// </summary>
        /// <param name="value">微信菜单按钮类型。</param>
        /// <param name="type">正在序列化的类型。</param>
        /// <param name="skip">是否跳过该项的序列化。</param>
        /// <returns>Json 字符串。</returns>
        public override string Serialize(object value, Type type, ref bool skip)
        {
            if (value is MenuButtonType)
            {
                var btnType = (MenuButtonType)value;
                switch (btnType)
                {
                    case MenuButtonType.None:
                        {
                            return "\"\"";
                        }
                    case MenuButtonType.Click:
                        {
                            return "\"click\"";
                        }
                    case MenuButtonType.View:
                        {
                            return "\"view\"";
                        }
                    default:
                        {
                            return "\"\"";
                        }
                }
            }
            else
            {
                return "\"\"";
            }
        }
    }
}
