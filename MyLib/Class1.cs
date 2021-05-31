using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    class CustomBinder : SerializationBinder
    {
        public override Type BindToType
        (string assemblyName, string typeName)
        {
            Assembly currentasm = Assembly.GetExecutingAssembly();
            return Type.GetType($"{currentasm.GetName().Name}.{typeName.Split('.')[1]}");
        }
    }

    public class SerializeAndDeserialize
    {
        public static Message Serialize(object anySerializableObject)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Binder = new CustomBinder();
            using (var memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream,
                anySerializableObject);
                return new Message
                {
                    Data = memoryStream.ToArray()
                };
            }
        }

        public static object Deserialize(Message message)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Binder = new CustomBinder();
            using (var memoryStream = new MemoryStream(message.Data))
            {
                return formatter.Deserialize(memoryStream);
            }
        }
    }    [Serializable]
4 public class Message
5 {
6 public byte[] Data { get; set; }
7 }
8[Serializable]
9 public class ComplexMessage
10 {
    11 public Message First { get; set; }
12 public Message Second { get; set; }
13 public int NumberStatus { get; set; }
14 }

}
