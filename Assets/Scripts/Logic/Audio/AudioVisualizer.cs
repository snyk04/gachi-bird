#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GachiBird.Audio
{
    public class AudioVisualizer : IDisposable
    {
        private readonly AudioSource _audioSource;

        private readonly FFTWindow _fftWindow;

        private readonly GameObject _partPrefab;
        private readonly GameObject _partContainer;

        private readonly int _size;

        private readonly Transform[] _cubes;
        private readonly float[] _spectrumData;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public AudioVisualizer(
            AudioSource audioSource, SpectrumDataSize spectrumDataSize, FFTWindow fftWindow, GameObject partPrefab,
            GameObject partContainer
        )
        {
            _audioSource = audioSource;
            _fftWindow = fftWindow;
            _partPrefab = partPrefab;
            _partContainer = partContainer;
            _size = (int)spectrumDataSize;

            _cubes = new Transform[_size];
            _spectrumData = new float[_size];
        }

        public void Start()
        {
            CreateVisualizers();
            VisualizeAsync(_cancellationSource.Token);
        }

        private void CreateVisualizers()
        {
            for (int i = 0; i < _size; i++)
            {
                GameObject gameObj = Object.Instantiate(_partPrefab, _partContainer.transform);
                _cubes[i] = gameObj.transform;
                _cubes[i].transform.localPosition += new Vector3(i * 20, 0);
            }
        }

        private async void VisualizeAsync(CancellationToken cancellation)
        {
            while (!cancellation.IsCancellationRequested)
            {
                _audioSource.GetSpectrumData(_spectrumData, 0, _fftWindow);

                for (int i = 0; i < _size; i++)
                {
                    _cubes[i].localScale = new Vector3(1, _spectrumData[i] * 100);
                }

                await Task.Yield();
            }
        }

        public void Dispose() => _cancellationSource.Cancel();
    }
}
