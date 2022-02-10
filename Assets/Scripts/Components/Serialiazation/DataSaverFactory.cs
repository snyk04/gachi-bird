#nullable enable

namespace GachiBird.Serialization
{
    public static class DataSaverFactory
    {
        public static IDataSaver<TData> Get<TData>(string relativePath)
        {
            return new DataEncryptedJsonSaver<TData>(relativePath);
        }
    }
}
