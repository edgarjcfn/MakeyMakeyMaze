using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Sonar _sonar;
	public float time;

	public float moveSpeed;

	// Use this for initialization
	void Start () {
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

		//transform.Translate(horizontalTranslate, 0, verticalTranslate);
		rigidbody.AddForce(horizontalTranslate, 0, verticalTranslate, ForceMode.VelocityChange);

		time -= Time.deltaTime;

		if (time <= 0)
		{
			Application.LoadLevel("GameOver");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "GameOver")
		{
			Application.LoadLevel("You Win");
		}
	}

	void OnGUI()
	{
		GUI.color = Color.green;
		GUI.Label(new Rect(10, 10, 200, 100), "Time: " + (int) time);
	}
}
