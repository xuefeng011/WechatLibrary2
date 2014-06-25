using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization.Json;

namespace WechatLibrary.Model.Return
{
    public class NewsUploadReturn : ReturnBase
    {
        [Json(Name = "type")]
        public string Type
        {
            get;
            set;
        }

        [Json(Name = "media_id")]
        public string MediaId
        {
            get;
            set;
        }

        [Json(Name = "created_at")]
        public long CreatedAt
        {
            get;
            set;
        }
    }
}
