#nullable enable

using System.Text;
using UnityEngine;

namespace GachiBird.Serialization
{
    public class DataJsonSaver<TData> : DataSaver<TData>
    {
        public DataJsonSaver(string relativePath) : base(relativePath) { }
        
        protected override byte[] Serialize(TData saveData)
        {
            string dataAsText = JsonUtility.ToJson(saveData);

            return Encoding.UTF8.GetBytes(dataAsText);
        }

        protected override bool TryDeserialize(byte[] dataAsBytes, out TData saveData)
        {
            string dataAsText = Encoding.UTF8.GetString(dataAsBytes);

            saveData = JsonUtility.FromJson<TData>(dataAsText);

            return saveData != null;
        }
    }
}
