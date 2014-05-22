using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Converter
{
    public partial class AutoResponseResultConverter
    {
        public static ResponseResultBase ConvertTo(object responseResult)
        {
            if (responseResult is TextAutoResponseResult)
            {
                return ConvertTo(responseResult as TextAutoResponseResult);
            }
            else if (responseResult is ImageAutoResponseResult)
            {
                return ConvertTo(responseResult as ImageAutoResponseResult);
            }
            else if (responseResult is VoiceAutoResponseResult)
            {
                return ConvertTo(responseResult as VoiceAutoResponseResult);
            }
            else if (responseResult is VideoAutoResponseResult)
            {
                return ConvertTo(responseResult as VideoAutoResponseResult);
            }
            else if (responseResult is MusicAutoResponseResult)
            {
                return ConvertTo(responseResult as MusicAutoResponseResult);
            }
            else if (responseResult is NewsAutoResponseResult)
            {
                return ConvertTo(responseResult as NewsAutoResponseResult);
            }
            else
            {
                return new EmptyResult();
            }
        }

        public static ResponseResultBase ConvertTo(TextAutoResponseResult responseResult)
        {
            return new TextResult()
            {
                Content = responseResult.Content
            };
        }

        public static ResponseResultBase ConvertTo(ImageAutoResponseResult responseResult)
        {
            return new ImageResult()
            {
                MediaId = responseResult.MediaId
            };
        }

        public static ResponseResultBase ConvertTo(VoiceAutoResponseResult responseResult)
        {
            return new VoiceResult()
            {
                MediaId = responseResult.MediaId
            };
        }

        public static ResponseResultBase ConvertTo(VideoAutoResponseResult responseResult)
        {
            return new VideoResult()
            {
                Title = responseResult.Title,
                Description = responseResult.Description,
                MediaId = responseResult.MediaId
            };
        }

        public static ResponseResultBase ConvertTo(MusicAutoResponseResult responseResult)
        {
            return new MusicResult()
            {
                Description = responseResult.Description,
                HQMusicUrl = responseResult.HQMusicUrl,
                MusicURL = responseResult.MusicURL,
                ThumbMediaId = responseResult.ThumbMediaId,
                Title = responseResult.Title
            };
        }

        public static ResponseResultBase ConvertTo(NewsAutoResponseResult responseResult)
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            foreach (var newsAutoResponseArticle in responseResult.NewsAutoResponseArticles)
            {
                newsArticles.Add(new NewsArticle()
                {
                    Description = newsAutoResponseArticle.Description,
                    PicUrl = newsAutoResponseArticle.PicUrl,
                    Title = newsAutoResponseArticle.Title,
                    Url = newsAutoResponseArticle.Url
                });
            }
            return new NewsResult()
            {
                Articles = newsArticles
            };
        }
    }
}
