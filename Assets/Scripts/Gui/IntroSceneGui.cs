using UnityEngine;
using System.Collections;

public class IntroSceneGui : MonoBehaviour {

	// Use this for initialization
	void Start () {

		var playMessage = GameObject.Find("Play").GetComponent<UIButtonMessage>();
		playMessage.target = gameObject;
		playMessage.functionName = "OnPlayClick";

		var optionsMessage = GameObject.Find("Options").GetComponent<UIButtonMessage>();
		optionsMessage.target = gameObject;
		optionsMessage.functionName = "OnOptionsClick";
	}

	void OnOptionsClick()
	{
		Application.LoadLevel("Settings");
	}

	void OnPlayClick()
	{
		Application.LoadLevel("GameScene");
	}
}
