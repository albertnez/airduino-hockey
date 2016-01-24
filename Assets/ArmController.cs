using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {
	private ArduinoBridge arduino;
	private Vector3 baseRotation;
	private float velocityx = 0;
	private float velocityy = 0;
	private float velocityz = 0;
	private float smoothTime = 0.5f;
	private float lerp = 0.1f;
	private Vector3 lastRotation;

	// Use this for initialization
	void Start () {
		arduino = (ArduinoBridge)this.GetComponent(typeof(ArduinoBridge));
		baseRotation = new Vector3 (0, 0, 0);
		lastRotation = new Vector3 (90, 180, 180);
	}
	
	// Update is called once per frame
	void Update () {
		arduino.WriteToArduino ("IMU\r");
		string raw = arduino.ReadFromArduino (100);
		float imux = 0, imuy = 0, imuz = 0;
		bool anyNull = false;
		if (raw != null) {
			imux = -float.Parse (raw) * 360;
		} else {
			anyNull = true;
		}
		raw = arduino.ReadFromArduino (50);
		if (raw != null) {
			imuy = -float.Parse (raw) * 360;
		} else {
			anyNull = true;
		}
		raw = arduino.ReadFromArduino (50);
		if (raw != null) {
			imuz = -float.Parse (raw) * 360;
		} else {
			anyNull = true;
		}
		if (anyNull) {
			Debug.LogError("had nulls beatch");
			return;
		}
		// Vector3 originalRotation = transform.localEulerAngles;
		Vector3 originalRotation = lastRotation;

		Vector3 newRot = new Vector3 (imuz, imuy, imux);
		Debug.Log (imux);
		Debug.Log (imuy);
		Debug.Log (imuz);
		if (Input.GetKeyDown ("space")) {
			baseRotation = new Vector3(90 - newRot.x, 180 - newRot.y, 180 - newRot.z);
			velocityx = velocityy = velocityz = 0;
			return;
		}

		Vector3 targetRotation = new Vector3(
			baseRotation.x + newRot.x,
			baseRotation.y + newRot.y,
			baseRotation.z + newRot.z
		);

		/*
		float elapsedRotationx = Mathf.SmoothDampAngle(originalRotation.x, targetRotation.x, ref velocityx, smoothTime);
		float elapsedRotationy = Mathf.SmoothDampAngle(originalRotation.y, targetRotation.y, ref velocityy, smoothTime);
		float elapsedRotationz = Mathf.SmoothDampAngle(originalRotation.z, targetRotation.z, ref velocityz, smoothTime);
		Vector3 elapsedRotation = new Vector3 (elapsedRotationx, elapsedRotationy, elapsedRotationz);
		transform.localEulerAngles = elapsedRotation;
		*/

		float elapsedRotationx = Mathf.LerpAngle(originalRotation.x, targetRotation.x, lerp);
		float elapsedRotationy = Mathf.LerpAngle(originalRotation.y, targetRotation.y, lerp);
		float elapsedRotationz = Mathf.LerpAngle(originalRotation.z, targetRotation.z, lerp);

		Vector3 elapsedRotation = new Vector3 (elapsedRotationx + 360 % 360, elapsedRotationy + 360 % 360, elapsedRotationz + 360 % 360);

		transform.localEulerAngles = elapsedRotation;

		// transform.localEulerAngles = targetRotation;
		lastRotation = elapsedRotation;
	}
}