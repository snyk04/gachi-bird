#nullable enable

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace GachiBird.Serialization
{
    public class DataSaver<TData> : IDataSaver<TData>
    {
        protected readonly BinaryFormatter Formatter = new BinaryFormatter();
        protected readonly string Path;

        public DataSaver(string relativePath)
        {
            Path = $"{Application.persistentDataPath}/{relativePath}";
        }

        public virtual bool TryLoadSaveData(out TData saveData)
        {
            if (File.Exists(Path))
            {
                using FileStream file = File.Open(Path, FileMode.Open);
                
                if (Formatter.Deserialize(file) is TData deserializedData)
                {
                    saveData = deserializedData;

                    return true;
                }
            }

            saveData = default;
            
            return false;
        }

        public virtual void Save(TData saveData)
        {
            using FileStream file = File.Create(Path);
            Formatter.Serialize(file, saveData);
        }
    }
}
