using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.AutoResponse.Result
{
    public partial class MusicAutoResponseResult
    {
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string MusicURL
        {
            get;
            set;
        }

        public string HQMusicUrl
        {
            get;
            set;
        }

        public string ThumbMediaId
        {
            get;
            set;
        }
    }
}
