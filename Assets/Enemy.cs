using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float minX = -6.0f;
	public float maxX = 0.0f;
	public float speed = 10.0f;
	public float maxSpeed = 10.0f;
	public GameObject disk;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (disk == null) {
			return;
		}
		float target = disk.transform.position.z - transform.position.z;
		float targetX = disk.transform.position.x;
		if (targetX > 0.0f) {
			targetX = -5.0f;
		}
		float diffX = targetX - transform.position.x;
		if (diffX > 0 && transform.position.x > maxX ||
		    diffX < 0 && transform.position.x < minX) {
			diffX = 0;
		}
		rb.velocity = new Vector3(diffX, 0.0f, Mathf.Min(maxSpeed, target * speed));
	}
}
