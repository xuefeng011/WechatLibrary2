using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Return
{
    /// <summary>
    /// 通过网页授权获取到的用户信息。
    /// </summary>
    public partial class OAuth2UserInfoReturn : ReturnBase
    {
        /// <summary>
        /// 用户的唯一标识。
        /// </summary>
        [Json(Name = "openid")]
        public string OpenId
        {
            get;
            set;
        }

        /// <summary>
        /// 用户昵称。
        /// </summary>
        [Json(Name = "nickname")]
        public string NickName
        {
            get;
            set;
        }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知。
        /// </summary>
        [Json(Name = "sex")]
        public string Sex
        {
            get;
            set;
        }

        /// <summary>
        /// 用户个人资料填写的省份。
        /// </summary>
        [Json(Name = "province")]
        public string Province
        {
            get;
            set;
        }

        /// <summary>
        /// 普通用户个人资料填写的城市。
        /// </summary>
        [Json(Name = "city")]
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// 国家，如中国为 CN。
        /// </summary>
        [Json(Name = "country")]
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有 0、46、64、96、132 数值可选，0 代表 640*640 正方形头像），用户没有头像时该项为空。
        /// </summary>
        [Json(Name = "headimgurl")]
        public string HeadImgUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）。
        /// </summary>
        [Json(Name = "privilege")]
        public string[] Privileges
        {
            get;
            set;
        }
    }
}
