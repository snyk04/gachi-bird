using System;
using System.Text;
using UnityEngine;

namespace GachiBird.Serialization
{
    public class DataJsonSaver : DataSaver
    {
        protected override string RelativePath { get; }

        public DataJsonSaver(string relativePath)
        {
            RelativePath = relativePath;
        }
        
        protected override byte[] Serialize<TData>(TData saveData)
        {
            string dataAsText = JsonUtility.ToJson(saveData);

            return Encoding.UTF8.GetBytes(dataAsText);
        }

        protected override bool TryDeserialize<TData>(byte[] dataAsBytes, out TData? saveData)
        {
            string dataAsText = Encoding.UTF8.GetString(dataAsBytes);

            saveData = JsonUtility.FromJson<TData>(dataAsText);

            return saveData != null;
        }

        // todo: waiting for C# update
        protected override bool TryDeserialize<TData>(byte[] dataAsBytes, out TData? saveData)
            where TData : default
        {
            string dataAsText = Encoding.UTF8.GetString(dataAsBytes);

            saveData = JsonUtility.FromJson<TData>(dataAsText);

            return saveData != null;
        }
    }
}
