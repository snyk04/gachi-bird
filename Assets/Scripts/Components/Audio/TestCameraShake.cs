using AreYouFruits.Common.ComponentGeneration;
using GachiBird.CameraMovement;
using GachiBird.Environment.Objects;
using UnityEngine;

namespace GachiBird.Audio
{
    public class TestCameraShake : MonoBehaviour
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IFlexDependentCameraEffect>> _cameraShaker;
        [SerializeField] private BoosterSettings _boosterSettings;
        [SerializeField] private AudioSource _analyzedAudioSource;
#nullable enable
        
        private void Start()
        {
            _analyzedAudioSource.clip = _boosterSettings.BoosterInfo.Music;
            _cameraShaker.GetHeldItem().Enable(_boosterSettings.BoosterInfo);
        }
    }
}