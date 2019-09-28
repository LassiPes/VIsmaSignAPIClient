using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace VismaSignClientLib
{
    public class Converter
    {
        public static byte[] ObjectToByteArray(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

    }
}
