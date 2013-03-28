using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SettingsSceneGui : MonoBehaviour {

	public GameObject propertyPrefab;
	public GameObject anchor;

	private List<DynamicProperty> _displayedSettings = new List<DynamicProperty>();

	// Use this for initialization
	void Start () {
		var saveMessage = GameObject.Find("Save").GetComponent<UIButtonMessage>();
		saveMessage.target = gameObject;
		saveMessage.functionName = "OnSaveClick";

		DisplayProperties();
	}

	private void DisplayProperties()
	{
		var y = 0f;
		foreach (var setting in Settings.SavedSettings)
		{
			var settingGUI = InstantiateSettingInput(setting);
			settingGUI.transform.position = new Vector3(0, y, 0);
			y -= 0.2f;
		}
	}

	private GameObject InstantiateSettingInput(string setting)
	{
		GameObject clone = NGUITools.AddChild(anchor, propertyPrefab);

		var dynamicProperty = clone.GetComponent<DynamicProperty>();
		dynamicProperty.label.text = setting;
		dynamicProperty.input.text = Settings.LoadSetting(setting);

		_displayedSettings.Add(dynamicProperty);

		return clone;
		
	}

	void OnSaveClick()
	{
		SaveAllConfigurations();
		Application.LoadLevel("IntroScene");
	}

	private void SaveAllConfigurations()
	{
		foreach (var settingsGUI in _displayedSettings)
		{
			Settings.SaveSetting(settingsGUI.label.text, settingsGUI.input.text);
		}
	}

}
