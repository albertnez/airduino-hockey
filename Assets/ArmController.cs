using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {
	private ArduinoBridge arduino;
	private Vector3 baseRotation;

	// Use this for initialization
	void Start () {
		arduino = (ArduinoBridge)this.GetComponent(typeof(ArduinoBridge));
		baseRotation = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		arduino.WriteToArduino ("IMU\r");
		string raw = arduino.ReadFromArduino (100);
		if (raw == null)
			return;
		float imux = -float.Parse (raw) * 360;
		float imuy = -float.Parse (arduino.ReadFromArduino (50)) * 360;
		float imuz = float.Parse (arduino.ReadFromArduino (50)) * 360;
		Vector3 newRot = new Vector3 (imuz, imuy, imux);
		Debug.Log (imux);
		Debug.Log (imuy);
		Debug.Log (imuz);
		if (Input.GetKeyDown ("space")) {
			baseRotation = new Vector3(90 - newRot.x, 180 - newRot.y, 180 - newRot.z);
		}
		transform.localEulerAngles = new Vector3(
			baseRotation.x + newRot.x,
			baseRotation.y + newRot.y,
			baseRotation.z + newRot.z
		);
	}
}