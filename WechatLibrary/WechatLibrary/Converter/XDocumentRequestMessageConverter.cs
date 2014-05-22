using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Request.Event;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.Converter
{
    public partial class XDocumentRequestMessageConverter
    {
        /// <summary>
        /// 反序列化 XDocument 到指定的消息类。
        /// </summary>
        /// <param name="document">XDocument。</param>
        /// <param name="type">消息类的类型。</param>
        /// <returns>消息类的实例。</returns>
        public static object Deserialize(XDocument document, Type type)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var instance = Activator.CreateInstance(type);

            var root = document.Root;

            foreach (var field in type.GetFields())
            {
                string fieldName = field.Name;
                XElement fieldElement = root.Element(fieldName);

                if (fieldElement != null)
                {
                    field.SetValue(instance, Convert.ChangeType(fieldElement.Value, field.FieldType));
                }
            }

            foreach (var property in type.GetProperties())
            {
                string propertyName = property.Name;
                XElement propertyElement = root.Element(propertyName);

                if (propertyElement != null)
                {
                    property.SetValue(instance, Convert.ChangeType(propertyElement.Value, property.PropertyType), null);
                }
            }

            return instance;
        }

        /// <summary>
        /// 反序列化 XDocument 到指定的消息类。
        /// </summary>
        /// <typeparam name="T">消息类的类型。</typeparam>
        /// <param name="document">XDocument。</param>
        /// <returns>消息类的实例。</returns>
        public static T Deserialize<T>(XDocument document)
        {
            return (T)Deserialize(document, typeof(T));
        }

        public static RequestMessageBase Deserialize(XDocument document, RequestMessageType messageType)
        {

            switch (messageType)
            {
                case RequestMessageType.Text:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<TextMessage>(document);
                    }
                case RequestMessageType.Image:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<ImageMessage>(document);
                    }
                case RequestMessageType.Voice:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<VoiceMessage>(document);
                    }
                case RequestMessageType.Video:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<VideoMessage>(document);
                    }
                case RequestMessageType.Location:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<LocationMessage>(document);
                    }
                case RequestMessageType.Link:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<LinkMessage>(document);
                    }
                case RequestMessageType.Subscribe:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<SubscribeMessage>(document);
                    }
                case RequestMessageType.QRSubscribe:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<QRSubscribeMessage>(document);
                    }
                case RequestMessageType.Unsubscribe:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<UnsubscribeMessage>(document);
                    }
                case RequestMessageType.QRScan:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<QRScanMessage>(document);
                    }
                case RequestMessageType.UploadLocation:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<UploadLocationMessage>(document);
                    }
                case RequestMessageType.MenuButtonClick:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<MenuButtonClickMessage>(document);
                    }
                case RequestMessageType.MenuButtonView:
                    {
                        return XDocumentRequestMessageConverter.Deserialize<MenuButtonViewMessage>(document);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
