using UnityEngine;
using System.Collections;

public class handle : MonoBehaviour {

	public float speed = 10.0f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float nx = 0.0f;
		if (Input.GetAxis ("Vertical") > 0) {
			nx = -speed;
		}
		else if (Input.GetAxis ("Vertical") < 0) {
			nx = speed;
		}
		float nz = 0.0f;
		if (Input.GetAxis ("Horizontal") < 0) {
			nz = -speed;
		}
		else if (Input.GetAxis ("Horizontal") > 0) {
			nz = speed;
		}
		rb.velocity = new Vector3(nx, rb.velocity.y, nz);
		//rb.velocity = new Vector3(10.0f, 0.0f, 0.0f);
	}
}
