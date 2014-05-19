using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WechatLibrary.Service.Converter
{
    public class XDocumentRequestMessageConverter
    {
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
    }
}
