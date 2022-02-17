using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common;
using GachiBird.Audio;
using GachiBird.Environment.Objects;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class VisualFlexer
    {
        private static readonly int AmplitudeId = Shader.PropertyToID("_Amplitude");

        private CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public VisualFlexer(
            Material material, IFlexModeHandler flexModeHandler, ISoundAnalyzer soundAnalyzer, float threshold,
            float maxValue
        )
        {
            flexModeHandler.OnFlexModeStart += HandleFlexStart;

            flexModeHandler.OnFlexModeEnd += HandleFlexEnd;

            async void HandleFlexStart(BoosterInfo boosterInfo)
            {
                _cancellationSource = new CancellationTokenSource();

                while (!_cancellationSource.IsCancellationRequested)
                {
                    float amplitude = soundAnalyzer.GetAmplitude(
                        boosterInfo.MusicFrequencyRange,
                        threshold,
                        maxValue
                    );

                    material.SetFloat(AmplitudeId, amplitude);

                    await Task.Yield();
                }
            }

            void HandleFlexEnd()
            {
                _cancellationSource.Cancel();
                material.SetFloat(AmplitudeId, 0.0f);
            }
        }
    }
}
