using UnityEngine;
using System.Collections;

public class PlayAgainButton : MonoBehaviour {



	// Use this for initialization
	void Start () {
		var msg = GetComponent<UIButtonMessage>();
		msg.target = gameObject;
		msg.functionName = "OnPlayAgainClick";
	}

	void OnPlayAgainClick()
	{
		Application.LoadLevel("GameScene");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
