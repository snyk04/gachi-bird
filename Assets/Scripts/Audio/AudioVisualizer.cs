using UnityEngine;

namespace GachiBird.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioVisualizer : MonoBehaviour
    {
        [SerializeField] private AudioClip _audio;
        
        [Header("Analyzing")]
        [SerializeField] private SpectrumDataSize _spectrumDataSize;
        [SerializeField] private FFTWindow _fftWindow;

        [Header("Visualizing")]
        [SerializeField] private GameObject _prefab;
        [SerializeField] private GameObject _container;

        private AudioSource _audioSource;
        
        private int _size;
        
        private Transform[] _cubes;
        private float[] _spectrumData;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            
            _size = (int) _spectrumDataSize;
            
            _cubes = new Transform[_size];
            _spectrumData = new float[_size];
        }
        private void Start()
        {
            _audioSource.clip = _audio;
            _audioSource.Play();

            CreateVisualizers();
        }
        private void FixedUpdate()
        {
            Visualize();
        }
        
        private void CreateVisualizers()
        {
            for (int i = 0; i < _size; i++)
            {
                GameObject gameObj = Instantiate(_prefab, _container.transform);
                _cubes[i] = gameObj.transform;
                _cubes[i].transform.localPosition += new Vector3(i * 20, 0);
            }
        }
        private void Visualize()
        {
            _audioSource.GetSpectrumData(_spectrumData, 0, _fftWindow);
            for (int i = 0; i < _size; i++)
            {
                _cubes[i].localScale = new Vector3(1, _spectrumData[i] * 100);
            }
        }
    }
}
