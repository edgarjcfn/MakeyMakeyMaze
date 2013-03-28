using UnityEngine;
using System.Collections;

public class GiveUpButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var buttonMessage = GetComponent<UIButtonMessage>();
		buttonMessage.target = gameObject;
		buttonMessage.functionName = "OnButtonClick";
	}

	void OnButtonClick()
	{
		Application.LoadLevel("IntroScene");
	}
	
}
