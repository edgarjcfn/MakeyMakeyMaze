using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float time;

	void Update () {

		time -= Time.deltaTime;

		if (time <= 0)
		{
			Application.LoadLevel("GameOver");
		}
	}

	void OnGUI()
	{
		GUI.color = Color.green;
		GUI.Label(new Rect(10, 10, 200, 100), "Time: " + (int)time);
	}
}
