using System.Collections.Generic;
using UnityEngine;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;

namespace cln.Sources.Services
{
	public class DataService : IService
	{
		private const string Keys = "keys";
		private List<string> _keys;

		// Insert database here, PlayerPrefs, folder or cloud adapter
		public DataService()
		{
			Dbg.Log("DataService is Started".Color(Color.green));
		}

		public void Initialize()
		{
		}

		// REVIEW: Try a more generic approach
		
		public void SetBool(string key, string value)
		{
			
		}

		public void SetInt(string key, int value)
		{
		}

		public void SetFloat(string key, float value)
		{
		}

		public void SetDouble(string key, double value)
		{
		}

		public void SetLong(string key, long value)
		{
		}

		public void SetString(string key, string value)
		{
		}

		public bool GetBool(string key)
		{
			return false;
		}

		public int GetInt(string key)
		{
			return 0;
		}

		public float GetFloat(string key)
		{
			return 0f;
		}

		public double GetDouble(string key)
		{
			return 0;
		}

		public long GetLong(string key)
		{
			return 0;
		}

		public string GetString(string key)
		{
			return string.Empty;
		}
	}
}