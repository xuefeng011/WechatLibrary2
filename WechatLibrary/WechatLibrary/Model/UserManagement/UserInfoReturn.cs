﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Common.Serialization.Json;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Model.UserManagement
{
    /// <summary>
    /// 用户信息。
    /// </summary>
    [Table("UserInfo")]
    public class UserInfoReturn : ReturnBase
    {
        [Json(Ignore = true)]
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        [Json("subscribe")]
        public int Subscribe
        {
            get;
            set;
        }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        [Json("openid")]
        public string OpenId
        {
            get;
            set;
        }

        /// <summary>
        /// 用户的昵称
        /// </summary>
        [Json("nickname")]
        public string NickName
        {
            get;
            set;
        }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        [Json("sex")]
        public int Sex
        {
            get;
            set;
        }

        /// <summary>
        /// 用户所在城市
        /// </summary>
        [Json("city")]
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// 用户所在国家
        /// </summary>
        [Json("country")]
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// 用户所在省份
        /// </summary>
        [Json("province")]
        public string Province
        {
            get;
            set;
        }

        /// <summary>
        /// 用户的语言，简体中文为zh_CN
        /// </summary>
        [Json("language")]
        public string Language
        {
            get;
            set;
        }

        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </summary>
        [Json("headimgurl")]
        public string HeadImgUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        [Json("subscribe_time")]
        public long SubscribeTime
        {
            get;
            set;
        }

        /// <summary>
        /// 该用户消息在数据库创建的时间
        /// </summary>
        [Json(Ignore = true)]
        public DateTime CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 刷新资料时间。
        /// </summary>
        [Json(Ignore = true)]
        public DateTime RefreshTime
        {
            get;
            set;
        }
    }
}
