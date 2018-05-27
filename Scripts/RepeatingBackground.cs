using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D groundCollider;
	private float groundHorizontalLength;

	private void Awake() {
		groundCollider = GetComponent<BoxCollider2D>();
	}


	// Use this for initialization
	void Start () {
		// Getting the X-Size of the object "Ground" (Width)
		groundHorizontalLength = groundCollider.size.x;
	}

	private void RepositionBackground(){
		//In the official tutorial, to scroll the background
		//Vector2 groundOffset = new Vector2 (groundHorizontalLength * 2f, 0);
		//transform.position = (Vector2)transform.position + groundOffset;

		transform.Translate (Vector2.right * groundHorizontalLength * 2);
	}


	// Update is called once per frame
	void Update () {
		// When the background moves to the left the whole width, we put it on the right
		if (transform.position.x < -groundHorizontalLength) {
			RepositionBackground ();
		}
	}
}
