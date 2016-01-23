using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class ArduinoBridge : MonoBehaviour {
	private SerialPort stream;

	// Use this for initialization
	void Start () {
		stream = new SerialPort("/dev/cu.usbserial-A6008eDI", 115200);
		stream.ReadTimeout = 50;
		stream.Open();
	}

	public void WriteToArduino (string message) {
		stream.WriteLine(message);
		stream.BaseStream.Flush();
	}

	public string ReadFromArduino (int timeout = 0) {
		int oldTimeout = stream.ReadTimeout;
		string result = null;

		stream.ReadTimeout = timeout;
		try {
			result = stream.ReadLine();
		} catch (TimeoutException) {}
		stream.ReadTimeout = oldTimeout;
		return result;
	}

	public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity) {
		DateTime initialTime = DateTime.Now;
		DateTime nowTime;
		TimeSpan diff = default(TimeSpan);
		string dataString = null;

		do {
			try {
				dataString = stream.ReadLine();
			} catch (TimeoutException) {
				dataString = null;
			}

			if (dataString != null) {
				callback (dataString);
				yield return null;
			} else {
				yield return new WaitForSeconds (0.05f);
			}

			nowTime = DateTime.Now;
			diff = nowTime - initialTime;
		} while (diff.Milliseconds < timeout);

		if (fail != null) {
			fail();
		}
		yield return null;
	}
}