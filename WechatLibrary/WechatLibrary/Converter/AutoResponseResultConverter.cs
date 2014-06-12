using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Converter
{
    /// <summary>
    /// 自动回复消息实体转换到回复消息。
    /// </summary>
    internal partial class AutoResponseResultConverter
    {
        /// <summary>
        /// 转换回复消息实体到回复消息基类。
        /// </summary>
        /// <param name="responseResult">回复消息实体。</param>
        /// <returns>消息基类。</returns>
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

        /// <summary>
        /// 转换回复文本消息实体到回复文本消息。
        /// </summary>
        /// <param name="responseResult">回复文本消息实体。</param>
        /// <returns>回复文本消息。</returns>
        public static ResponseResultBase ConvertTo(TextAutoResponseResult responseResult)
        {
            return new TextResult()
            {
                Content = responseResult.Content
            };
        }

        /// <summary>
        /// 转换回复图片消息实体到回复图片消息。
        /// </summary>
        /// <param name="responseResult">回复图片消息实体。</param>
        /// <returns>回复图片消息。</returns>
        public static ResponseResultBase ConvertTo(ImageAutoResponseResult responseResult)
        {
            return new ImageResult()
            {
                MediaId = responseResult.MediaId
            };
        }

        /// <summary>
        /// 转换回复语音消息实体到回复语音消息。
        /// </summary>
        /// <param name="responseResult">回复语音消息实体。</param>
        /// <returns>回复语音消息。</returns>
        public static ResponseResultBase ConvertTo(VoiceAutoResponseResult responseResult)
        {
            return new VoiceResult()
            {
                MediaId = responseResult.MediaId
            };
        }

        /// <summary>
        /// 转换回复视频消息实体到回复视频消息。
        /// </summary>
        /// <param name="responseResult">回复视频消息实体。</param>
        /// <returns>回复视频消息。</returns>
        public static ResponseResultBase ConvertTo(VideoAutoResponseResult responseResult)
        {
            return new VideoResult()
            {
                Title = responseResult.Title,
                Description = responseResult.Description,
                MediaId = responseResult.MediaId
            };
        }

        /// <summary>
        /// 转换回复音乐消息实体到回复音乐消息。
        /// </summary>
        /// <param name="responseResult">回复音乐消息实体。</param>
        /// <returns>回复音乐消息。</returns>
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

        /// <summary>
        /// 转换回复图文消息实体到回复图文消息。
        /// </summary>
        /// <param name="responseResult">回复图文消息实体。</param>
        /// <returns>回复图文消息。</returns>
        public static ResponseResultBase ConvertTo(NewsAutoResponseResult responseResult)
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            foreach (var newsAutoResponseArticle in responseResult.NewsAutoResponseArticles.OrderBy(temp => temp.Index))
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
