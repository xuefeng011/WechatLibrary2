using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;
using WechatLibrary.Model.Menu;

namespace WechatLibrary.Model.Menu
{
    public class MenuButtonTypeConverter : JsonConverter
    {
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
