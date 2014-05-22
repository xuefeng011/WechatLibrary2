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
    public partial class MatchResultMapping
    {
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        public Guid MatchId
        {
            get;
            set;
        }

        public string MatchType
        {
            get;
            set;
        }

        public Guid ResultId
        {
            get;
            set;
        }

        public string ResultType
        {
            get;
            set;
        }

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

        public static object GetMapping(TextMessageMatch match)
        {
            var mapping = match.MatchResultMapping;
            return GetMapping(mapping.ResultType, mapping.ResultId);
        }
    }
}
