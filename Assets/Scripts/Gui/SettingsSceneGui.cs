using UnityEngine;
using System.Collections;

public class SettingsSceneGui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var saveMessage = GameObject.Find("Save").GetComponent<UIButtonMessage>();
		saveMessage.target = gameObject;
		saveMessage.functionName = "OnSaveClick";
	}

	void OnSaveClick()
	{
		Application.LoadLevel("IntroScene");
	}

	void OnGUI()
	{
		GUI.Label(new Rect(100, 100, 100, 100), "Saved Settings : "+ Settings.SavedSettings.Length);
	}
}
