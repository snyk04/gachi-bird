using GoogleMobileAds.Api;
using UnityEngine;

namespace GachiBird.Monetization
{
    public class AdInitializer : MonoBehaviour
    {
        private void Awake()
        {
            MobileAds.Initialize(status => { });
        }
    }
}