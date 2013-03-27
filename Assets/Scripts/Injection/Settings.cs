using UnityEngine;
using System.Collections;
using System;

public static class Settings {

	private static string _settingsKey = "PlayerPrefKeys";

	public static void SaveSetting(string prefKey, object value)
	{
		addToSerializedKeys(prefKey);
		PlayerPrefs.SetString(prefKey, value.ToString());
	}

	public static object LoadSetting(string prefKey, System.Type type)
	{
		string value = PlayerPrefs.GetString(prefKey);

		if (type == typeof(int))
		{
			return int.Parse(value);
		}
		else if (type == typeof(float))
		{
			return float.Parse(value);
		}
		else if (type == typeof(string))
		{
			return value;
		}

		return null;
	}

	public static bool HasKey(string prefKey)
	{
		return PlayerPrefs.HasKey(prefKey);
	}

	public static string LoadSetting(string prefKey)
	{
		return PlayerPrefs.GetString(prefKey);
	}

	public static string[] SavedSettings
	{
		get
		{
			return PlayerPrefs.GetString(_settingsKey).Split(',');
		}
	}

	private static void addToSerializedKeys(string prefName)
	{
		string value = PlayerPrefs.GetString(_settingsKey);

		if (string.IsNullOrEmpty(value))
		{
			value = prefName;
		}
		else
		{
			if (value.IndexOf(prefName) == -1)
			{
				value += "," + prefName;
			}
		}

		PlayerPrefs.SetString(_settingsKey, value);
	}
}
