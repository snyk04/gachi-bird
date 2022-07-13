using System;

namespace GachiBird.Audio
{
    public enum SpectrumDataSize : short
    {
        Size64 = 64,
        Size128 = 128,
        Size256 = 256,
        Size512 = 512,
        Size1024 = 1024,
        Size2048 = 2048,
        Size4096 = 4096,
        Size8192 = 8192,
    }

    public static class SpectrumDataSizeExtensions
    {
        public static int GetPower(this SpectrumDataSize size)
        {
            return size switch
            {
                SpectrumDataSize.Size64 => 6,
                SpectrumDataSize.Size128 => 7,
                SpectrumDataSize.Size256 => 8,
                SpectrumDataSize.Size512 => 9,
                SpectrumDataSize.Size1024 => 10,
                SpectrumDataSize.Size2048 => 11,
                SpectrumDataSize.Size4096 => 12,
                SpectrumDataSize.Size8192 => 13,
                _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
            };
        }
    }
}
