using GoogleMobileAds.Api;
using zehreken.i_cheat;

namespace cln.Sources.Services
{
    public class AdService
    {
        private const string AppId = "ca-app-pub-8389931397130414~7907377047";
        private const string BannerId = "ca-app-pub-8389931397130414/3968132034";
        private const string TestBannerId = "ca-app-pub-3940256099942544/6300978111";
        private BannerView _bannerView;
        
        public AdService()
        {
            Dbg.Log("AdService is started");
            MobileAds.Initialize(AppId);
        }

        public void RequestBanner()
        {
            _bannerView = new BannerView(TestBannerId, AdSize.Banner, AdPosition.Top);

            AdRequest request = new AdRequest.Builder().Build();
            
            _bannerView.LoadAd(request);
        }
    }
}