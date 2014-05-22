using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.AutoResponse.Result
{
    public partial class VoiceAutoResponseResult
    {
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        public string MediaId
        {
            get;
            set;
        }
    }
}
