using AreYouFruits.Common;

namespace GachiBird.Audio
{
    public interface ISoundAnalyzer
    {
        int SpectrumLength { get; }
        Range<int> PossibleRange { get; }
        
        float GetAmplitude(Range<int> frequencyRange, float threshold, float maxValue);
        float[] GetSpectrum();
    }
}
