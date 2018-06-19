﻿using System.Collections;
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
            _bannerView = new BannerView(TestBannerId, AdSize.Banner, AdPosition.Top);
            _interstitialAd = new InterstitialAd(TestInterstitialId);
            RequestBanner();
        }

        public void RequestInterstitial()
        {
            if (!_interstitialAd.IsLoaded())
                _interstitialAd.LoadAd(new AdRequest.Builder().Build());
        }

        private IEnumerator RunInterstitialTimer()
        {
            _interstitialTimerReady = false;
            yield return new WaitForSeconds(InterstitialPeriod);
            _interstitialTimerReady = true;
        }

        public void RequestBanner()
        {
            _bannerView.LoadAd(new AdRequest.Builder().Build());
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