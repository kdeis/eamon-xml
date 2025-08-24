using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Helpers
{
    internal static class ParseHelpers
    {
        public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        public static T ParseXML<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }

        public static T ParseXML<T>(this string @this, Type[] additionalTypes) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T), additionalTypes).Deserialize(reader) as T;
        }

        public static string SerializeObject<T>(this T toSerialize)
        {
            var xmlSerializer = new XmlSerializer(toSerialize.GetType());
            String serialized = null;
            using (var ms = new MemoryStream())
            {
                using (var xw = XmlWriter.Create(ms,
                    new XmlWriterSettings()
                    {
                        Encoding = new UTF8Encoding(false),
                        Indent = true,
                        NewLineOnAttributes = true,
                    }))
                {
                    xmlSerializer.Serialize(xw, toSerialize);
                    serialized = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return serialized;
        }
    }
}