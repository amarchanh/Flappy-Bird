using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb2d;

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		// Getting the scrollSpeed from GameController to set the X scroll
		//rb2d.velocity = new Vector2 (GameController.instance.scrollSpeed, 0);

		// We choose right because the speed will multiply by 1,0 (velocity in Vector.right)
		rb2d.velocity = Vector2.right * GameController.instance.scrollSpeed;

	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver) {
			rb2d.velocity = Vector2.zero;
		}
	}
}
