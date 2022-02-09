#nullable enable

using AreYouFruits.Common;

namespace GachiBird.Audio
{
    public interface ISoundAnalyzer
    {
        float GetAmplitude(Range<int> frequencyRange, float minValue, float maxValue);
    }
}
