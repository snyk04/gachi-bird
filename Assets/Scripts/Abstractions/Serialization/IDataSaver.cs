#nullable enable

namespace GachiBird.Serialization
{
    public interface IDataSaver<TData>
    {
        bool TryLoadSaveData(out TData saveData);
        void Save(TData saveData);
    }
}
