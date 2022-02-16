using AreYouFruits.Common.Encryption;

namespace GachiBird.Serialization
{
    public class DataEncryptedJsonSaver<TData> : DataJsonSaver<TData>
    {
        private const byte EncryptOffset = 1;
        private readonly IEncryptor _encryptor = new SimpleEncryptor(EncryptOffset); 
        
        public DataEncryptedJsonSaver(string relativePath) : base(relativePath) { }

        protected override byte[] Serialize(TData saveData)
        {
            return _encryptor.Encrypt(base.Serialize(saveData));
        }

        protected override bool TryDeserialize(byte[] dataAsBytes, out TData saveData)
        {
            return base.TryDeserialize(_encryptor.Decrypt(dataAsBytes), out saveData);
        }
    }
}
