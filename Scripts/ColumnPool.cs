using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

	// Columns that will appear simultaneously in the screen
	public int columnPoolSize = 5;
	// Stores the prefab of column, which will load the columns prefab
	public GameObject columnPrefab;

	public float columnMin = -2.9f;
	public float columnMax =  1.4f;
	private float spawnXPosition = 10f;

	// Position where the columns will appear (at the beggining of the scene, out of the range of the camera
	private Vector2 objectPoolPosition = new Vector2 (-14, 0);

	private float timeSinceLastSpawned;
	// Time between columns generator
	public float spawnRate;

	private int currentColumn;

	// Array that store the columns reference
	private GameObject[] columns;

	// Use this for initialization
	void Start () {
		// At the start, we instance many objects as declare in columnPoolSize
		columns = new GameObject[columnPoolSize];
		for(int i = 0; i<columnPoolSize; i++) {
			// Quaternion = rotation. By default
			columns [i] = Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);
		}

		SpawnColumn ();
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawned += Time.deltaTime;
		if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate) {
			
			timeSinceLastSpawned = 0;
			SpawnColumn ();
		}
	}

	void SpawnColumn() {
		float spawnYPosition = Random.Range (columnMin, columnMax);
		columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

		currentColumn++;
		if (currentColumn >= columnPoolSize) {
			currentColumn = 0;
		}
	}
}
