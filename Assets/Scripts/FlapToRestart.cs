using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlapToRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Check if the Game is Over and if we click with the mouse on the creen after die to restart the game
        if (Input.GetMouseButtonDown(0))
        {
            // Load de main Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene("main"); --> This can be dangerous if we change the name of the Scene
        }
    }
}
