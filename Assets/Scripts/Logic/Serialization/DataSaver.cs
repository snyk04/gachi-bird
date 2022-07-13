using System;
using System.IO;
using UnityEngine;

namespace GachiBird.Serialization
{
    public abstract class DataSaver : IDataSaver
    {
        protected abstract string RelativePath { get; }
        protected string AbsolutePath => Path.Combine(Application.persistentDataPath, RelativePath);

        public bool TryLoadSaveData<TData>(out TData? saveData)
        {
            string absolutePath = AbsolutePath;
            
            if (File.Exists(absolutePath) && TryDeserialize(File.ReadAllBytes(absolutePath), out saveData))
            {
                return true;
            }

            saveData = default;

            return false;
        }

        public void Save<TData>(TData saveData)
        {
            File.WriteAllBytes(AbsolutePath, Serialize(saveData));
        }

        protected abstract byte[] Serialize<TData>(TData saveData);
        protected abstract bool TryDeserialize<TData>(byte[] dataAsBytes, out TData? saveData);
        
        // todo: waiting for C# update
        protected abstract bool TryDeserialize<TData>(byte[] dataAsBytes, out TData? saveData)
            where TData : struct;
    }
}
