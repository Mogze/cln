using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;

namespace cln.Sources.Services
{
    public class AdService : IService
    {
        private const string AppId = "ca-app-pub-8389931397130414~7907377047";
        private const string BannerId = "ca-app-pub-8389931397130414/3968132034";
        private const string InterstitialId = "ca-app-pub-8389931397130414/4716521742";
        private const string TestBannerId = "ca-app-pub-3940256099942544/6300978111";
        private const string TestInterstitialId = "ca-app-pub-3940256099942544/1033173712";
        private BannerView _bannerView;
        private const float InterstitialPeriod = 10f; // in seconds
        private bool _interstitialReady = true;
        private InterstitialAd _interstitialAd;

        public AdService()
        {
            Dbg.Log("AdService is started".Color(Color.green));
            MobileAds.Initialize(AppId);
        }

        public void Initialize()
        {
            _bannerView = new BannerView(TestBannerId, AdSize.Banner, AdPosition.Top);
            _interstitialAd = new InterstitialAd(TestInterstitialId);
            RequestBanner();
            RequestInterstitial();
        }

        private void RequestInterstitial()
        {
            _interstitialReady = false;
            Main.Instance.StartCoroutine(RunInterstitialTimer());
        }

        private IEnumerator RunInterstitialTimer()
        {
            Dbg.Log("loading interstitial");
            _interstitialAd.LoadAd(new AdRequest.Builder().Build());

            yield return new WaitForSeconds(InterstitialPeriod);
            _interstitialReady = true;
            Dbg.Log(_interstitialReady);
        }

        public void RequestBanner()
        {
            _bannerView.LoadAd(new AdRequest.Builder().Build());
        }

        public void ShowInterstitial()
        {
            Dbg.Log("loading " + _interstitialReady + " " + _interstitialAd.IsLoaded());
            if (_interstitialReady && _interstitialAd.IsLoaded())
            {
                _interstitialAd.Show();
                RequestInterstitial();
            }
            else if (!_interstitialAd.IsLoaded())
            {
                _interstitialAd.LoadAd(new AdRequest.Builder().Build());
            }
        }
    }
}