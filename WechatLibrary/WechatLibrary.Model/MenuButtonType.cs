using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model
{
    /// <summary>
    /// 菜单的响应动作类型，目前有 click、view 两种类型。
    /// </summary>
    public enum MenuButtonType
    {
        /// <summary>
        /// 不使用该按钮或该按钮下存在子级。
        /// </summary>
        None,

        /// <summary>
        /// click 类型。
        /// </summary>
        Click,

        /// <summary>
        /// view 类型。
        /// </summary>
        View
    }
}
