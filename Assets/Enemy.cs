using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

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
		float target = disk.transform.position.z - transform.position.z;
		rb.velocity = new Vector3(0.0f, 0.0f, Mathf.Min(maxSpeed, target * speed));
	}
}
