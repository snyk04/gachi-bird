namespace AreYouFruits.Common.Encryption
{
    public class SimpleEncryptor : IEncryptor
    {
        private readonly int _seed;
        private const byte SizeOfByte = sizeof(byte);

        public SimpleEncryptor(int seed)
        {
            _seed = seed;
        }
        
        public byte[] Encrypt(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)((int)data[i]).CircularShiftLeft(_seed, SizeOfByte);
            }

            return data;
        }

        public byte[] Decrypt(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)((int)data[i]).CircularShiftRight(_seed, SizeOfByte);
            }

            return data;
        }
    }
}
