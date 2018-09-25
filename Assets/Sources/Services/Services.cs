using System;
using System.Collections.Generic;

namespace cln.Sources.Services
{
	public static class Services
	{
		private static Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

		public static void Initialize()
		{
			_services.Add(typeof(DataService), new DataService());
			_services.Add(typeof(GpgService), new GpgService());
			_services.Add(typeof(AdService), new AdService());
			_services.Add(typeof(AudioService), new AudioService());

			foreach (var service in _services)
			{
				service.Value.Initialize();
			}
		}

		private static T GetService<T>()
		{
			return (T) _services[typeof(T)];
		}

		public static DataService GetDataService()
		{
			return GetService<DataService>();
		}

		public static GpgService GetGpgService()
		{
			return GetService<GpgService>();
		}

		public static AdService GetAdService()
		{
			return GetService<AdService>();
		}

		public static AudioService GetAudioService()
		{
			return GetService<AudioService>();
		}
	}
}