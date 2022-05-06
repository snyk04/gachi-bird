namespace GachiBird.Serialization
{
    public static class DataSaverFactory
    {
        public static IDataSaver<TData> Get<TData>(string relativePath)
            where TData : class
        {
            // TODO : It's used temporary, because other savers don't support Dictionary
            return new DataBinarySaver<TData>(relativePath);
        }
    }
}
