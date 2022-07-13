using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using GachiBird.UserInterface;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GachiBird.Monetization
{
    public class BannerAd : MonoBehaviour
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IUserInterfaceCycle>> _userInterfaceCycle;
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private string _bannerId;
#nullable enable
        
        private BannerView? _bannerView;

        private void Start()
        {
            _bannerView = new BannerView(_bannerId, AdSize.Banner, AdPosition.Bottom);
            AdRequest request = new AdRequest.Builder().Build();
            _bannerView.LoadAd(request);
            _bannerView.Hide();

            _userInterfaceCycle.GetHeldItem().OnWindowShow += windowType =>
            {
                if (windowType == WindowType.GameOver)
                {
                    _bannerView.Show();   
                }
            };
            
            _userInterfaceCycle.GetHeldItem().OnWindowHide += windowType =>
            {
                if (windowType == WindowType.GameOver)
                {
                    _bannerView.Hide();  
                }
            };
            
            _gameCycle.GetHeldItem().OnGameRestart += () =>
            {
                _bannerView.Destroy();
            };
        }
    }
}