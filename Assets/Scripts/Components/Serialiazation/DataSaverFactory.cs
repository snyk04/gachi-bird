namespace GachiBird.Serialization
{
    public static class DataSaverFactory
    {
        public static IDataSaver Get(string relativePath)
        {
            // TODO : It's used temporary, because other savers don't support Dictionary
            return new DataBinarySaver(relativePath);
        }
    }
}
