﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PgpsUtilsAEFC.utils
{

    /// <summary>
    /// This class extends the functionality of the StringWriter class, defining its
    /// encoding in utf-8.
    /// </summary>
    internal sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }

    /// <summary>
    /// This class offers a multitude of useful XML methods that make serializing, creating and
    /// reading XML easier.
    /// <remarks>The type parameters used in this class need to be of a Serializable.</remarks>
    /// </summary>
    public class XMLUtils
    {

        /// <summary>
        /// Serializes an object into an XML string.
        /// </summary>
        /// <typeparam name="T">A serializable class type</typeparam>
        /// <param name="obj">The object to serialize</param>
        /// <returns>The serialized XML text</returns>
        public static string SerializeToString<T>(object obj)
        {
            using (Utf8StringWriter s = new Utf8StringWriter())
            {
                XmlSerializer serializedData = new XmlSerializer(typeof(T));
                serializedData.Serialize(s, obj);
                return s.ToString();
            }
        }

        /// <summary>
        /// Serializes an object into a given file automatically.
        /// </summary>
        /// <typeparam name="T">A serializable class type</typeparam>
        /// <param name="filepath">The filepath to add the text to</param>
        /// <param name="obj">The object to serialize</param>
        public static void SerializeToFile<T>(string filepath, object obj)
        {
            string xml = XMLUtils.SerializeToString<T>(obj).Trim();
            FileUtils.DumpToFile(filepath, new List<string> {xml});
        }

        /// <summary>
        /// Deserializes an XML object from a file.
        /// </summary>
        /// <typeparam name="T">The object type to deserialize the file contents into</typeparam>
        /// <param name="filepath">The path to the file to be deserialized</param>
        /// <returns>An instance of T with the serialized information.</returns>
        public static T DeserializeFromFile<T>(string filepath)
        {
            using (FileStream file = File.Open(filepath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T) serializer.Deserialize(file);
            }
        }

        /// <summary>
        /// Deserializes the file into a string.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the string into</typeparam>
        /// <param name="str">The string to deserialize</param>
        /// <returns>An instance of T with the serialized information.</returns>
        public static T DeserializeFromString<T>(string str)
        {
            using (StringReader s = new StringReader(str))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T) serializer.Deserialize(s);
            }
        }
    }
}