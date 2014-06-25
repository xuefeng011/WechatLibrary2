using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Return
{
    public class GetUserListReturn : ReturnBase
    {
        /// <summary>
        /// 关注该公众账号的总用户数。
        /// </summary>
        [Json(Name = "total")]
        public int Total
        {
            get;
            set;
        }

        /// <summary>
        /// 拉取的OPENID个数，最大值为10000。
        /// </summary>
        [Json(Name = "count")]
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// 列表数据，OPENID的列表。
        /// </summary>
        [Json(Name = "data")]
        public GetUserListReturnData Data
        {
            get;
            set;
        }

        /// <summary>
        /// 拉取列表的后一个用户的OPENID。
        /// </summary>
        [Json(Name = "next_openid")]
        public string NextOpenId
        {
            get;
            set;
        }
    }

    public class GetUserListReturnData
    {
        [Json(Name = "openid")]
        public List<string> OpenId
        {
            get;
            set;
        }
    }
}
