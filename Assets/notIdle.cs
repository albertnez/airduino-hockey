using UnityEngine;
using System.Collections;

public class notIdle : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (transform.position.x < 0)
			GetComponent<Rigidbody>().AddForce(-0.1f,0,0);
		else
			GetComponent<Rigidbody>().AddForce(0.1f,0,0);
			
	}
}
