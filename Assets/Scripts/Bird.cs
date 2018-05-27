using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// flag to determine if the bird is dead or alive
	private bool isDead;
	//Reference to Rigidbody2D from Unity (Physics in Bird element)
	private Rigidbody2D rb2d;
	// Reference to Animator from Unity (Animation from Bird element)
	private Animator anim;
	// Variable to determine the force to up the bird when tap (Declares as public to can edit from Unity )
	public float upForce = 200f;

    private RotateBird rotateBird;


	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        rotateBird = GetComponent<RotateBird>();
	}

	// Use this for initialization
	private void Start () {

	}

	// Update is called once per frame
	private void Update () {
		// Check if the Bird is alive
		if(isDead) return;

		// When doing right click from mouse...
		if(Input.GetMouseButtonDown(0)) {
			// The bird Stops to fall (Velocity from vector equals 0)
			rb2d.velocity = Vector2.zero;
			// Adding upForce from magnitude of upFoce value
			rb2d.AddForce(Vector2.up * upForce);
			anim.SetTrigger("Flap");
			SoundSystem.instance.PlayFlap ();

		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		isDead = true;
		anim.SetTrigger("Die");
        rotateBird.enabled = false;
        // Instance to GameController Singleton
        GameController.instance.BirdDie();
        rb2d.velocity = Vector2.zero;
		SoundSystem.instance.PlayHit ();
	}
}
