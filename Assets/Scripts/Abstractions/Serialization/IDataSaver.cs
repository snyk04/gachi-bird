namespace GachiBird.Serialization
{
    public interface IDataSaver<TData>
        where TData : class
    {
        bool TryLoadSaveData(out TData? saveData);
        void Save(TData saveData);
    }
}
