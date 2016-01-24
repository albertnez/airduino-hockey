using UnityEngine;
using System.Collections;

public class handle : MonoBehaviour {

	public float speed = 10.0f;
	public float maxX = 9.5f;
	public float minX = 3.2f;
	public float maxZ = 2.8f;
	public float minZ = -2.8f;
	Rigidbody rb;

	// Use this for initialization
	void Start() {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float nx = 0.0f;
		if (Input.GetAxis ("Vertical") > 0 && transform.position.x > minX) {
			nx = -speed;
		}
		else if (Input.GetAxis ("Vertical") < 0 && transform.position.x < maxX) {
			nx = speed;
		}
		float nz = 0.0f;
		if (Input.GetAxis ("Horizontal") < 0 && transform.position.z > minZ) {
			nz = -speed;
		}
		else if (Input.GetAxis ("Horizontal") > 0 && transform.position.z < maxZ) {
			nz = speed;
		}
		rb.velocity = new Vector3(nx, rb.velocity.y, nz);
		//rb.velocity = new Vector3(10.0f, 0.0f, 0.0f);
	}
}
