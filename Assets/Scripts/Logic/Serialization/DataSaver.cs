using System.IO;
using UnityEngine;

namespace GachiBird.Serialization
{
    public abstract class DataSaver<TData> : IDataSaver<TData>
        where TData : class
    {
        private readonly string _path;

        protected DataSaver(string relativePath)
        {
            _path = $"{Application.persistentDataPath}/{relativePath}";
        }

        public bool TryLoadSaveData(out TData? saveData)
        {
            if (File.Exists(_path) && TryDeserialize(File.ReadAllBytes(_path), out saveData))
            {
                return true;
            }

            saveData = default;

            return false;
        }

        public void Save(TData saveData)
        {
            File.WriteAllBytes(_path, Serialize(saveData));
        }

        protected abstract byte[] Serialize(TData saveData);
        protected abstract bool TryDeserialize(byte[] dataAsBytes, out TData? saveData);
    }
}
