using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

	public int playerScore = 0;
	public int enemyScore = 0;

	public GameObject playerScoreText;
	public GameObject enemyScoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Score(int player) {
		if (player == 1) {
			playerScore++;
			playerScoreText.GetComponent<TextMesh>().text = playerScore.ToString ();
		} else if (player == 2) {
			enemyScore++;
			enemyScoreText.GetComponent<TextMesh>().text = enemyScore.ToString ();
		} else {
			Debug.Log ("Error, increasing score of player " + player.ToString ());
		}
	}
}
