using System;
using System.Collections.Generic;
using UnityEngine;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;

namespace cln.Sources.Services
{
	public class DataService : IService
	{
		private const string Keys = "KEYS";
		private List<string> _keys = new List<string>();

		// Insert database here, PlayerPrefs, folder or cloud adapter
		public DataService()
		{
			Dbg.Log("DataService is Started".Color(Color.green));
			if (PlayerPrefs.HasKey("KEYS"))
			{
				_keys = JsonUtility.FromJson<List<string>>(PlayerPrefs.GetString(Keys));
			}
		}

		public void Initialize()
		{
		}

		// REVIEW: Try a more generic approach

		public void Set<T>(string key, T value, bool forceWrite = false)
		{
			if (!_keys.Contains(key))
			{
				_keys.Add(key);
			}

			PlayerPrefs.SetString(key, value.ToString());
			if (forceWrite)
			{
				ForceWrite();
			}
		}

		public T Get<T>(string key)
		{
			if (!_keys.Contains(key))
			{
				throw new Exception("Key not found");
			}

			return (T) Convert.ChangeType(PlayerPrefs.GetString(key), typeof(T));
		}

		private void ForceWrite()
		{
			var keysJson = JsonUtility.ToJson(_keys);
			PlayerPrefs.SetString(Keys, keysJson);
			PlayerPrefs.Save();
		}

		public void DeleteAll()
		{
			PlayerPrefs.DeleteAll();
		}

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