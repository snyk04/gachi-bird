using System;
using System.Threading;
using System.Threading.Tasks;
using GachiBird.Audio;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class SoundVisualizer : IDisposable
    {
        private readonly ISoundAnalyzer _soundAnalyzer;

        private float[] _leftSpectrumSamples;
        private readonly float[] _rightSpectrumSamples;
        
        private readonly Color[] _pixels;


        private readonly int _audioSpectrumId = Shader.PropertyToID("_AudioSpectrum");
        private readonly Texture2D _spectrumTexture;
        private CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public SoundVisualizer(Material audioMaterial, ISoundAnalyzer soundAnalyzer)
        {
            _soundAnalyzer = soundAnalyzer;

            _spectrumTexture = new Texture2D(_soundAnalyzer.SpectrumLength, 1, TextureFormat.RGBAFloat, false, true);

            _leftSpectrumSamples = new float[_soundAnalyzer.SpectrumLength];
            _rightSpectrumSamples = new float[_soundAnalyzer.SpectrumLength];
            _pixels = new Color[_soundAnalyzer.SpectrumLength];

            audioMaterial.SetTexture(_audioSpectrumId, _spectrumTexture);
        }

        public async void Start()
        {
            _cancellationSource = new CancellationTokenSource();

            while (!_cancellationSource.IsCancellationRequested)
            {
                _leftSpectrumSamples = _soundAnalyzer.GetSpectrum();

                ToColors(_leftSpectrumSamples, _rightSpectrumSamples, _pixels);

                _spectrumTexture.SetPixels(_pixels, 0);
                _spectrumTexture.Apply();

                await Task.Yield();
            }
        }

        private void ToColors(float[] leftSpectrumSamples, float[] rightSpectrumSamples, Color[] colors)
        {
            int length = colors.Length;

            if (leftSpectrumSamples.Length != length || rightSpectrumSamples.Length != length)
            {
                throw new ArgumentException("Arrays have different sizes.");
            }

            for (int i = 0; i < length; i++)
            {
                colors[i] = new Color(leftSpectrumSamples[i], rightSpectrumSamples[i], 0.0f, 0.0f);
            }
        }

        public void Dispose() => _cancellationSource.Cancel();
    }
}
