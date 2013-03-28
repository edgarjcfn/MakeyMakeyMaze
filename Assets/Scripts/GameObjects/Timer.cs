using UnityEngine;
using System.Collections;
using Injection;

public class Timer : MonoBehaviour {

	private UILabel _timerLabel;

	public float time;

	void Start()
	{
		//this.Inject();
		_timerLabel = GameObject.Find("TimerLabel").GetComponent<UILabel>();
	}

	void Update () {

		time -= Time.deltaTime;

		if (time <= 0)
		{
			Application.LoadLevel("GameOver");
		}

		_timerLabel.text =((int) time).ToString();
	}
}
