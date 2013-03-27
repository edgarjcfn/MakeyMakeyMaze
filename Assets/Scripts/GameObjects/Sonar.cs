using UnityEngine;
using System.Collections;
using Injection;

public class Sonar : MonoBehaviour {

	private Light _light;

	public float speed;
	public float maxRadius;

	[InjectFromPlayerPrefs("Sonar Intensity (Max)")]
	public float maxIntensity;
	
	// Use this for initialization
	void Start () {
		this.Inject();

		_light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_light.range < maxRadius)
		{
			_light.range += speed * 10f * Time.deltaTime;
		}
		if (_light.intensity > 0)
		{
			_light.intensity -= speed * Time.deltaTime;
		}
	}

	public void Beep()
	{
		_light.intensity = maxIntensity;
		_light.range = 0;
	}
}
