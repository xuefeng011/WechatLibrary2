using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.AutoResponse;
using WechatLibrary.Model.AutoResponse.Match;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Model.Menu;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Model
{
    /// <summary>
    /// 微信实体上下文。
    /// </summary>
    public partial class WechatEntities : DbContext
    {
        /// <summary>
        /// 微信帐号。
        /// </summary>
        public DbSet<WechatAccount> WechatAccounts
        {
            get;
            set;
        }

        /// <summary>
        /// 自动回复匹配结果集合。
        /// </summary>
        public DbSet<MatchResultMapping> MatchResultMappings
        {
            get;
            set;
        }

        /// <summary>
        /// 自动回复文本消息匹配集合。
        /// </summary>
        public DbSet<TextMessageMatch> TextMessageMatches
        {
            get;
            set;
        }

        /// <summary>
        /// 自动回复图片消息匹配集合。
        /// </summary>
        public DbSet<ImageMessageMatch> ImageMessageMatches
        {
            get;
            set;
        }

        /// <summary>
        /// 自动回复文本消息结果集合。
        /// </summary>
        public DbSet<TextAutoResponseResult> TextAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 自动回复图片消息结果集合。
        /// </summary>
        public DbSet<ImageAutoResponseResult> ImageAutoResponseResults
        {
            get;
            set;
        }


        /// <summary>
        /// 自动回复语音消息结果集合。
        /// </summary>
        public DbSet<VoiceAutoResponseResult> VoiceAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 自动回复视频消息结果集合。
        /// </summary>
        public DbSet<VideoAutoResponseResult> VideoAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 自动回复音乐消息结果集合。
        /// </summary>
        public DbSet<MusicAutoResponseResult> MusicAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// 自动回复图文消息结果集合。
        /// </summary>
        public DbSet<NewsAutoResponseResult> NewsAutoResponseResults
        {
            get;
            set;
        }

        /// <summary>
        /// AccessToken。
        /// </summary>
        public DbSet<AccessToken> AccessTokens
        {
            get;
            set;
        }

        /// <summary>
        /// 微信菜单。
        /// </summary>
        public DbSet<Menu.Menu> Menus
        {
            get;
            set;
        }

        /// <summary>
        /// 微信一级菜单按钮。
        /// </summary>
        public DbSet<Menu.MenuButton> MenuButtons
        {
            get;
            set;
        }

        /// <summary>
        /// 微信二级菜单按钮。
        /// </summary>
        public DbSet<Menu.MenuSubButton> MenuSubButtons
        {
            get;
            set;
        }

        /// <summary>
        /// 微信多媒体资源。
        /// </summary>
        public DbSet<WechatResource> WechatResources
        {
            get;
            set;
        }
    }
}
