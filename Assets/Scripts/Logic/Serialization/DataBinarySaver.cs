using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GachiBird.Serialization
{
    public class DataBinarySaver<TData> : DataSaver<TData>
    {
        protected readonly BinaryFormatter Formatter = new BinaryFormatter();

        public DataBinarySaver(string relativePath) : base(relativePath) { }

        protected override byte[] Serialize(TData saveData)
        {
            using var stream = new MemoryStream();
            Formatter.Serialize(stream, saveData);

            return stream.ToArray();
        }

        protected override bool TryDeserialize(byte[] dataAsBytes, out TData saveData)
        {
            using var stream = new MemoryStream(dataAsBytes);

            if (Formatter.Deserialize(stream) is TData deserializedData)
            {
                saveData = deserializedData;

                return true;
            }

            saveData = default;
            
            return false;
        }
    }
}
