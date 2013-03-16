using UnityEngine;
using System.Collections;

public class Sonar : MonoBehaviour {

	private Light _light;
	public float intensitySpeed;
	
	// Use this for initialization
	void Start () {
		_light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_light.intensity > 0)
		{
			_light.intensity -= intensitySpeed * Time.deltaTime;
		}
	}

	public void Beep()
	{
		_light.intensity = 2;
	}
}
