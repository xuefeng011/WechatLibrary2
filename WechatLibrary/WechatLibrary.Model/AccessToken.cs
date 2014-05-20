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
        private Guid _id;

        [Key]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _value;

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        private DateTime _expiresTime;

        public DateTime ExpiresTime
        {
            get
            {
                return _expiresTime;
            }
            set
            {
                _expiresTime = value;
            }
        }
    }
}
