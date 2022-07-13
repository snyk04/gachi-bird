using System;

namespace AreYouFruits.Common.Encryption
{
    public sealed class SimpleEncryptor : IEncryptor
    {
        private readonly int _seed;
        private const byte SizeOfByte = sizeof(byte);

        public SimpleEncryptor(int seed)
        {
            _seed = seed;
        }
        
        public void Encrypt(Span<byte> data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)((int)data[i]).CircularShiftLeft(_seed, SizeOfByte);
            }
        }

        public void Decrypt(Span<byte> data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)((int)data[i]).CircularShiftRight(_seed, SizeOfByte);
            }
        }
    }
}
