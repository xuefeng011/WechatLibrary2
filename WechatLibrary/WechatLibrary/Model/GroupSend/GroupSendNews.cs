using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization.Json;

namespace WechatLibrary.Model.GroupSend
{
    public class GroupSendNews : IGroupSend
    {
        private List<GroupSendNewsArticles> _articles;

        /// <summary>
        /// 图文消息，一个图文消息支持 1 到 10 条图文。
        /// </summary>
        [Json(Name = "articles")]
        public List<GroupSendNewsArticles> Articles
        {
            get
            {
                _articles = _articles ?? new List<GroupSendNewsArticles>();
                return _articles;
            }
            set
            {
                _articles = value;
            }
        }
    }

    public class GroupSendNewsArticles
    {
        /// <summary>
        /// 图文消息缩略图的 media_id，可以在基础支持-上传多媒体文件接口中获得。
        /// </summary>
        [Json(Name = "thumb_media_id")]
        public string ThumbMediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 图文消息的作者。
        /// </summary>
        [Json(Name = "author",Required = false)]
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// 图文消息的标题。
        /// </summary>
        [Json(Name = "title",Required = true)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 在图文消息页面点击“阅读原文”后的页面。
        /// </summary>
        [Json(Name = "content_source_url",Required = false)]
        public string ContentSourceUrl
        {
            get;
            set;
        }

        private string _content = string.Empty;

        /// <summary>
        /// 图文消息页面的内容，支持HTML标签。
        /// </summary>
        [Json(Name = "content", Required = true)]
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        /// <summary>
        /// 图文消息的描述。
        /// </summary>
        [Json(Name = "digest", Required = false)]
        public string Digest
        {
            get;
            set;
        }

        private string _showCoverPic = "0";

        /// <summary>
        /// 是否显示封面，1为显示，0为不显示。
        /// </summary>
        [Json(Name = "show_cover_pic", Required = false)]
        public string ShowCoverPic
        {
            get
            {
                return _showCoverPic;
            }
            set
            {
                _showCoverPic = value;
            }
        }
    }
}
