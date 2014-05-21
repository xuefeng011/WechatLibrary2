using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Model.Message.Response
{
    /// <summary>
    /// 回复消息基类。
    /// </summary>
    public abstract partial class ResponseResultBase
    {
        private string _toUserName;

        /// <summary>
        /// 接收方帐号（收到的 OpenID）。
        /// </summary>
        public string ToUserName
        {
            get
            {
                return _toUserName;
            }
            set
            {
                _toUserName = value;
            }
        }

        private string _fromUserName;

        /// <summary>
        /// 开发者微信号。
        /// </summary>
        public string FromUserName
        {
            get
            {
                return _fromUserName;
            }
            set
            {
                _fromUserName = value;
            }
        }

        private int _createTime;

        /// <summary>
        /// 消息创建时间（整型）。
        /// </summary>
        public int CreateTime
        {
            get
            {
                return _createTime;
            }
            set
            {
                _createTime = value;
            }
        }

        private string _msgType;

        /// <summary>
        /// 消息类型。
        /// </summary>
        public string MsgType
        {
            get
            {
                return _msgType;
            }
            set
            {
                _msgType = value;
            }
        }


        /// <summary>
        /// 序列化回复消息到 xml。
        /// </summary>
        /// <returns>xml。</returns>
        public virtual string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            Type t = this.GetType();
            sb.Append("<xml>");
            foreach (var field in t.GetFields())
            {
                var value = field.GetValue(this);
                if (value != null)
                {
                    string fieldName = field.Name;
                    sb.Append("<" + fieldName + ">");
                    if (field.FieldType.IsValueType == false)
                    {
                        sb.Append("<![CDATA[" + value.ToString() + "]]>");
                    }
                    else
                    {
                        sb.Append(value.ToString());
                    }
                    sb.Append("</" + fieldName + ">");
                }
            }
            foreach (var property in t.GetProperties())
            {
                var value = property.GetValue(this, null);
                if (value != null)
                {
                    string propertyName = property.Name;
                    sb.Append("<" + propertyName + ">");
                    if (property.PropertyType.IsValueType == false)
                    {
                        sb.Append("<![CDATA[" + value.ToString() + "");
                    }
                    else
                    {
                        sb.Append(value.ToString());
                    }
                    sb.Append("</" + propertyName + ">");
                }
            }
            sb.Append("</xml>");
            return sb.ToString();
        }
    }
}
