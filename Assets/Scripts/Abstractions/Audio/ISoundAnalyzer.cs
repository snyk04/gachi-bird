using AreYouFruits.Common;

namespace GachiBird.Audio
{
    public interface ISoundAnalyzer
    {
        float GetAmplitude(Range<int> frequencyRange, float threshold, float maxValue);
    }
}
