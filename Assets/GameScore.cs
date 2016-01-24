using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

	public int playerScore = 0;
	public int enemyScore = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Score(int player) {
		if (player == 1) {
			playerScore++;
		} else if (player == 2) {
			enemyScore++;
		} else {
			Debug.Log ("Error, increasing score of player " + player.ToString ());
		}
	}
}
