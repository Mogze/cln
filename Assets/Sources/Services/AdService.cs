using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;

namespace cln.Sources.Services
{
    public class AdService : IService
    {
        // Game ad ads
        private const string AppId = "app-id";
        private const string BannerId = "banner-id";
        private const string InterstitialId = "interstitial-id";
        private const string InterstitialVideoId = "interstitial-video-id";
        private const string RewardedVideoId = "rewarded-video-id";
        // Test ad Ids
        private const string TestBannerId = "ca-app-pub-3940256099942544/6300978111";
        private const string TestInterstitialId = "ca-app-pub-3940256099942544/1033173712";
        private const string TestInterstitialVideoId = "ca-app-pub-3940256099942544/8691691433";
        private const string TestRewardedVideoId = "ca-app-pub-3940256099942544/5224354917";
        private BannerView _bannerView;
        private const float InterstitialPeriod = 30f; // in seconds
        private bool _interstitialTimerReady = true;
        private InterstitialAd _interstitialAd;

        public AdService()
        {
            Dbg.Log("AdService is started".Color(Color.green));
            MobileAds.Initialize(AppId);
        }

        public void Initialize()
        {
            Dbg.Log("AdService is initialized");
            _bannerView = new BannerView(BannerId, AdSize.Banner, AdPosition.Top);
            _interstitialAd = new InterstitialAd(InterstitialId);
            RequestBanner();
        }

        public void RequestInterstitial()
        {
            if (!_interstitialAd.IsLoaded())
            {
                _interstitialAd.LoadAd(new AdRequest.Builder()
                    .AddExtra("max_ad_content_rating", "G")
//                    .AddExtra("tag_for_under_age_of_consent", "true")
                    .Build());
            }
        }

        private IEnumerator RunInterstitialTimer()
        {
            _interstitialTimerReady = false;
            yield return new WaitForSeconds(InterstitialPeriod);
            _interstitialTimerReady = true;
        }

        public void RequestBanner()
        {
            _bannerView.LoadAd(new AdRequest.Builder()
                .AddExtra("max_ad_content_rating", "G")
//                .AddExtra("tag_for_under_age_of_consent", "true")
                .Build());
        }

        public void ShowInterstitial()
        {
            if (_interstitialTimerReady && _interstitialAd.IsLoaded())
            {
                _interstitialAd.Show();
                Main.Instance.StartCoroutine(RunInterstitialTimer());
            }
        }
    }
}