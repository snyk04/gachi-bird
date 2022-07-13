using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GachiBird.Serialization
{
    public sealed class DataBinarySaver : DataSaver
    {
        private readonly BinaryFormatter _formatter = new BinaryFormatter();
        protected override string RelativePath { get; }

        public DataBinarySaver(string relativePath)
        {
            RelativePath = relativePath;
        }

        protected override byte[] Serialize<TData>(TData saveData)
        {
            using var stream = new MemoryStream();
            _formatter.Serialize(stream, saveData);

            return stream.ToArray();
        }

        protected override bool TryDeserialize<TData>(byte[] dataAsBytes, out TData? saveData)
        {
            using var stream = new MemoryStream(dataAsBytes);

            if (_formatter.Deserialize(stream) is TData deserializedData)
            {
                saveData = deserializedData;

                return true;
            }

            saveData = default;
            
            return false;
        }

        // todo: waiting for C# update
        protected override bool TryDeserialize<TData>(byte[] dataAsBytes, out TData? saveData)
            where TData : default
        {
            using var stream = new MemoryStream(dataAsBytes);

            if (_formatter.Deserialize(stream) is TData deserializedData)
            {
                saveData = deserializedData;

                return true;
            }

            saveData = default;
            
            return false;
        }
    }
}
