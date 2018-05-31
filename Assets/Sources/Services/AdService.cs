using GoogleMobileAds.Api;
using zehreken.i_cheat;

namespace cln.Sources.Services
{
    public class AdService
    {
        private const string AppId = "ca-app-pub-8389931397130414~7907377047";
        private const string BannerId = "ca-app-pub-8389931397130414/3968132034";
        private BannerView _bannerView;
        
        public AdService()
        {
            Dbg.Log("AdService is started");
            MobileAds.Initialize(AppId);
        }

        public void RequestBanner()
        {
            _bannerView = new BannerView(BannerId, AdSize.Banner, AdPosition.Top);
        }
    }
}