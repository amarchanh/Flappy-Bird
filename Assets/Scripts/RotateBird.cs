using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBird : MonoBehaviour {

	public float MaxDownVelocity = -10f;
	public float MaxDownAngle = -90f;

	private Rigidbody2D rb2d;

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D> ();

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rb2d) {
            // Store the value of the current Velocity between the current velocity and the max velocity, to set the angle of the bird when falling
            float currentVelocity = Mathf.Clamp (rb2d.velocity.y, MaxDownVelocity, 0);
            float angle = (currentVelocity / MaxDownVelocity) * MaxDownAngle;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
		}
	}
}
