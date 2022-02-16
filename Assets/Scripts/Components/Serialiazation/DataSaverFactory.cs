namespace GachiBird.Serialization
{
    public static class DataSaverFactory
    {
        public static IDataSaver<TData> Get<TData>(string relativePath)
            where TData : class
        {
            return new DataEncryptedJsonSaver<TData>(relativePath);
        }
    }
}
