namespace GachiBird.Serialization
{
    public interface IDataSaver
    {
        bool TryLoadSaveData<TData>(out TData? saveData);
        void Save<TData>(TData saveData);
    }
}
