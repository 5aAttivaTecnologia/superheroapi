using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace Template.Framework
{
    public sealed class Serializador
    {
        public static string SerializaXml(object objeto)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objeto.GetType());
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, objeto);

                return stringWriter.ToString();
            }
        }

        public static string SerializaJson(object objeto)
        {
            return JsonConvert.SerializeObject
                (
                    objeto, 
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }
                );
        }

        public static T DeserializaJson<T>(string valor)
        {
            return JsonConvert.DeserializeObject<T>(valor);
        }
    }
}
