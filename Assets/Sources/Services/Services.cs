using System.Collections.Generic;

namespace cln.Sources.Services
{
    public static class Services
    {
        private static List<IService> _services = new List<IService>();

        public static void Initialize()
        {
            _services.Add(new AdService());
            _services.Add(new AudioService());

            foreach (var service in _services)
            {
                service.Initialize();
            }
        }

        public static IService GetAdService()
        {
            return (AdService) _services[0];
        }

        public static IService GetAudioService()
        {
            return (AudioService) _services[1];
        }
    }
}