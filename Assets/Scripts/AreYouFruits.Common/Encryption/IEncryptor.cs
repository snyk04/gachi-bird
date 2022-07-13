using System;

namespace AreYouFruits.Common.Encryption
{
    public interface IEncryptor
    {
        void Encrypt(Span<byte> data);
        void Decrypt(Span<byte> data);
    }
}
