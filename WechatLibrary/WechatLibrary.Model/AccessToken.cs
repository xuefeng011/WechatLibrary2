using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model
{
    public class AccessToken
    {
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public DateTime ExpiresTime
        {
            get;
            set;
        }
    }
}
