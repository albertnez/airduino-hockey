using UnityEngine;
using System.Collections;

public class ArmColliderVelocity : MonoBehaviour {

	public GameObject thingToMirror;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = (thingToMirror.transform.position - transform.position)/Time.fixedDeltaTime;

	}
}
