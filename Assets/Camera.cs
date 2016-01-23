using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public GameObject player;
	private float velocityx = 0;
	private float velocityy = 0;
	private float velocityz = 0;
	private float smoothTime = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 originalRotation = transform.rotation.eulerAngles;
		Transform original = transform;
		transform.LookAt (player.transform.position);
		Vector3 targetRotation = transform.rotation.eulerAngles;
		
		transform.TransformDirection(originalRotation);
		float elapsedRotationx = Mathf.SmoothDampAngle(originalRotation.x,targetRotation.x,ref velocityx,smoothTime);
		float elapsedRotationy = Mathf.SmoothDampAngle(originalRotation.y,targetRotation.y,ref velocityy,smoothTime);
		float elapsedRotationz = Mathf.SmoothDampAngle(originalRotation.z,targetRotation.z,ref velocityz,smoothTime);
		//transform.rotation.SetLookRotation(new Vector3(elapsedRotationx,elapsedRotationy,elapsedRotationz));
	}
}
