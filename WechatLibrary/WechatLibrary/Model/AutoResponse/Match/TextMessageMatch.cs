using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.Model.AutoResponse.Match
{
    /// <summary>
    /// 文本消息自动匹配。
    /// </summary>
    public partial class TextMessageMatch
    {
        private Guid _id;

        /// <summary>
        /// 数据库主键。
        /// </summary>
        [Key]
        [ForeignKey("WechatAccount")]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _matchContent;

        /// <summary>
        /// 匹配文本。
        /// </summary>
        public string MatchContent
        {
            get
            {
                return _matchContent;
            }
            set
            {
                _matchContent = value;
            }
        }

        private string _matchOption;

        /// <summary>
        /// 匹配方式。
        /// equals：完全匹配。
        /// equalsignore：忽略大小写完全匹配。
        /// contains：部分匹配。
        /// containsignore：忽略大小写部分匹配。
        /// </summary>
        public string MatchOption
        {
            get
            {
                return _matchOption;
            }
            set
            {
                _matchOption = value;
            }
        }

        private int _matchLevel;

        /// <summary>
        /// 匹配等级。数字越小优先匹配。仅在部分匹配下有效。
        /// </summary>
        public int MatchLevel
        {
            get
            {
                return _matchLevel;
            }
            set
            {
                _matchLevel = value;
            }
        }

        /// <summary>
        /// 是否需要先匹配上一条记录再执行本条自动回复。
        /// </summary>
        public virtual TextMessageMatch RequirePrevMessageMatch
        {
            get;
            set;
        }

        /// <summary>
        /// 映射该文本消息自动回复的内容。
        /// </summary>
        public virtual MatchResultMapping MatchResultMapping
        {
            get;
            set;
        }

        /// <summary>
        /// 拥有该文本消息自动回复的微信帐号。
        /// </summary>
        public virtual WechatAccount WechatAccount
        {
            get;
            set;
        }

        /// <summary>
        /// 指示该匹配是否成功匹配指定的文本消息。
        /// </summary>
        /// <param name="message">文本消息。</param>
        /// <returns>是否匹配成功。</returns>
        public bool IsMatch(TextMessage message)
        {
            switch (this.MatchOption)
            {
                case "equals":
                    {
                        if (this.MatchContent == message.Content)
                        {
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "equalsignore":
                    {
                        if (string.Equals(this.MatchContent, message.Content, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "contains":
                    {
                        if (this.MatchContent != null && this.MatchContent.Contains(message.Content) == true)
                        {
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "containsignore":
                    {
                        if (this.MatchContent != null && this.MatchContent.IndexOf(message.Content) > -1)
                        {
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                default:
                    {
                        return false;
                    }
            }
            if (this.RequirePrevMessageMatch == null)
            {
                return true;
            }
            else
            {
                if (this.RequirePrevMessageMatch.IsMatch(message) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
