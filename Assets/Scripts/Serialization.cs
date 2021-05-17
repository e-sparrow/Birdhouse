using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils
{
    public static class Serialization
    {
        public static void Serialize(object obj, string directory, ESerializationMethod method)
        {
            switch (method)
            {
                case ESerializationMethod.Xml:
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    using (StreamWriter writer = new StreamWriter(directory))
                    {
                        serializer.Serialize(writer, obj); 
                    }
                    break;
                case ESerializationMethod.Json:
                    using (StreamWriter stream = new StreamWriter(directory))
                    {
                        stream.Write(JsonUtility.ToJson(obj, true));
                    }
                    break;
                case ESerializationMethod.Binary:
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream stream = new FileStream(directory, FileMode.Create))
                    {
                        formatter.Serialize(stream, obj);
                    }
                    break;
                default:
                    throw new Exception("Not provided serialization method!");
            }
        }

        public static T Deserialize<T>(string directory, ESerializationMethod method)
        {
            switch (method)
            {
                case ESerializationMethod.Xml:
                    XmlSerializer deserializer = new XmlSerializer(typeof(T));
                    using (TextReader reader = new StreamReader(directory))
                    {
                        return (T) deserializer.Deserialize(reader);
                    }
                case ESerializationMethod.Json:
                    using (StreamReader stream = new StreamReader(directory))
                    {
                        return JsonUtility.FromJson<T>(stream.ReadToEnd());
                    }
                case ESerializationMethod.Binary:
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream stream = new FileStream(directory, FileMode.Open))
                    {
                        return (T) formatter.Deserialize(stream);
                    }
                default:
                    throw new Exception("Not provided serialization method!");

            }
        }

        public static void Save(string text, string directory)
        {
            using (StreamWriter stream = new StreamWriter(directory))
            {
                stream.Write(text);
            }
        }

        public static string Load(string directory)
        {
            using (StreamReader stream = new StreamReader(directory))
            {
                return stream.ReadToEnd();
            }
        }
    }
}
