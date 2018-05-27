using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

	// Trigger that start when one collider steps into another. Making a collision
	// If any other collider enters the specific collider, the method returns the score + 1
	private void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag ("Player")) {
			GameController.instance.BirdScored ();
		}
	
	}

}
