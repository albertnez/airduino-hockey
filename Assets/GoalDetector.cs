using UnityEngine;
using System.Collections;

public class GoalDetector : MonoBehaviour {

	public GameScore gameScore;
	public int playerScorer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("disk")) {
			gameScore.Score(playerScorer);
			other.transform.position = new Vector3(0.0f, 0.2f, 0.0f);
			float dirX = 2.0f;
			if (playerScorer == 1) {
				dirX *= -1.0f;
			}
			other.GetComponent<Rigidbody>().velocity = new Vector3(dirX, 0.0f, 0.0f);

		}
	}
}
