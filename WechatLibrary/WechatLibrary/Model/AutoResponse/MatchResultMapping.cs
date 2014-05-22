using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.AutoResponse.Match;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.Model.AutoResponse
{
    /// <summary>
    /// 自动回复匹配与结果映射。
    /// </summary>
    public partial class MatchResultMapping
    {
        /// <summary>
        /// 数据库主键。
        /// </summary>
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// 匹配的主键。
        /// </summary>
        public Guid MatchId
        {
            get;
            set;
        }

        /// <summary>
        /// 匹配的类型。
        /// </summary>
        public string MatchType
        {
            get;
            set;
        }

        /// <summary>
        /// 结果的主键。
        /// </summary>
        public Guid ResultId
        {
            get;
            set;
        }

        /// <summary>
        /// 结果的类型。
        /// </summary>
        public string ResultType
        {
            get;
            set;
        }

        /// <summary>
        /// 根据结果类型和结果主键获取自动回复结果。
        /// </summary>
        /// <param name="resultType">结果类型。</param>
        /// <param name="resultId">结果主键。</param>
        /// <returns>自动回复结果。</returns>
        public static object GetMapping(string resultType, Guid resultId)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                switch (resultType)
                {
                    case "text":
                        {
                            return entities.TextAutoResponseResults.FirstOrDefault(temp => temp.Id == resultId);
                        }
                    case "image":
                        {
                            return entities.ImageAutoResponseResults.FirstOrDefault(temp => temp.Id == resultId);
                        }
                    case "voice":
                        {
                            return entities.VoiceAutoResponseResults.FirstOrDefault(temp => temp.Id == resultId);
                        }
                    case "video":
                        {
                            return entities.VideoAutoResponseResults.FirstOrDefault(temp => temp.Id == resultId);
                        }
                    case "music":
                        {
                            return entities.MusicAutoResponseResults.FirstOrDefault(temp => temp.Id == resultId);
                        }
                    case "news":
                        {
                            return entities.MusicAutoResponseResults.FirstOrDefault(temp => temp.Id == resultId);
                        }
                    default:
                        {
                            return null;
                        }
                }
            }
        }

        /// <summary>
        /// 根据匹配获取自动回复结果。
        /// </summary>
        /// <param name="match">匹配。</param>
        /// <returns>自动回复结果。</returns>
        public static object GetMapping(TextMessageMatch match)
        {
            var mapping = match.MatchResultMapping;
            return GetMapping(mapping.ResultType, mapping.ResultId);
        }

        /// <summary>
        /// 根据匹配获取自动回复结果。
        /// </summary>
        /// <param name="match">匹配。</param>
        /// <returns>自动回复结果。</returns>
        public static object GetMapping(ImageMessageMatch match)
        {
            var mapping = match.MatchResultMapping;
            return GetMapping(mapping.ResultType, mapping.ResultId);
        }
    }
}
