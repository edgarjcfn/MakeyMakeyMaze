using UnityEngine;
using System.Collections;
using Injection;

public class Player : MonoBehaviour {

	private Sonar _sonar;

	[InjectFromPlayerPrefs("Move Speed")]
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		this.Inject();
		_sonar = transform.Find("Sonar").GetComponent<Sonar>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
		{
			_sonar.Beep();
		}

		var horizontalTranslate = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		var verticalTranslate = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

		rigidbody.AddForce(horizontalTranslate, 0, verticalTranslate, ForceMode.VelocityChange);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "GameOver")
		{
			Application.LoadLevel("You Win");
		}
	}
}
