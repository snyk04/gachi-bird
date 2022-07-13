using AreYouFruits.Common.Encryption;

namespace GachiBird.Serialization
{
    public class DataEncryptedJsonSaver : DataJsonSaver
    {
        private const byte DefaultEncryptOffset = 1;
        
        public readonly byte EncryptOffset;
        private readonly IEncryptor _encryptor;

        public DataEncryptedJsonSaver(string relativePath, byte encryptOffset = DefaultEncryptOffset) : base(
            relativePath
        )
        {
            EncryptOffset = encryptOffset;
            _encryptor = new SimpleEncryptor(EncryptOffset);
        }

        protected override byte[] Serialize<TData>(TData saveData)
        {
            byte[] bytes = base.Serialize(saveData);

            _encryptor.Encrypt(bytes);

            return bytes;
        }

        protected override bool TryDeserialize<TData>(byte[] dataAsBytes, out TData? saveData)
        {
            _encryptor.Decrypt(dataAsBytes);
            
            return base.TryDeserialize(dataAsBytes, out saveData);
        }

        // todo: waiting for C# update
        protected override bool TryDeserialize<TData>(byte[] dataAsBytes, out TData? saveData)
            where TData : default
        {
            _encryptor.Decrypt(dataAsBytes);
            
            return base.TryDeserialize(dataAsBytes, out saveData);
        }
    }
}
