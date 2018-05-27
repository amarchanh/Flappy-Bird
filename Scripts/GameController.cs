using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Singleton Instance
	public static GameController instance;

	public GameObject gameOverText;
	public bool gameOver;
	public float scrollSpeed = -1.5f;

	private int score;
	public Text scoreText;

	private void Awake () {
		// Check if there is 
		if (GameController.instance == null) {
			GameController.instance = this;
		} else if(GameController.instance != this) {
			Destroy(gameObject);
			Debug.LogWarning ("GameController ha sido instanciado por segunda vez");
		}
	}

	public void BirdScored() {
		if (gameOver) return;

		score++;
		scoreText.text = "Score: " + score;
		SoundSystem.instance.PlayCoin ();
	}

	public void BirdDie() {
		gameOverText.SetActive(true);
		gameOver = true;
	}

	private void OnDestroy() {
		if (GameController.instance == this) {
			// Initilize GameController.instance to null in case we call GameController after an execution (The bird dies and the game restart)
			GameController.instance = null;
		}

	}

}
