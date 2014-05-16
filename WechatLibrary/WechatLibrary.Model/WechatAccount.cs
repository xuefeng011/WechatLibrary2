using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model
{
    public class WechatAccount
    {
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        [Required]
        public string AppId
        {
            get;
            set;
        }

        [Required]
        public string Secret
        {
            get;
            set;
        }

        [Required]
        public string Token
        {
            get;
            set;
        }

        public Menu Menu
        {
            get;
            set;
        }
    }
}
