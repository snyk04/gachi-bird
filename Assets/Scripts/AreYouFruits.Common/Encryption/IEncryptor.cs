namespace AreYouFruits.Common.Encryption
{
    public interface IEncryptor
    {
        byte[] Encrypt(byte[] data);
        byte[] Decrypt(byte[] data);
    }
}
