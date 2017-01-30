using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public int spawnWait;
	public int startWait;
	public int waveWait;
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private int score;

	public void Start() 
	{
		StartCoroutine(SpawnWaves ());
		score = 0;
		scoreText.text = "Score: " + score;
		restartText.text = "";
		gameOverText.text = "";

		gameOver = false;


	}

	public void Update()
	{
		if (gameOver) 
		{
			if (Input.GetKeyDown(KeyCode.R)){
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	private IEnumerator SpawnWaves() 
	{
		yield return new WaitForSeconds (startWait);

		while (true) {


			for (int i = 0; i < hazardCount; i++) {

				GameObject hazard = hazards [Random.Range (0, hazards.Length)];

				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity; //no rotation
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				break;
			}
		}
	}

	public void AddScore (int scoreDelta) 
	{
		score += scoreDelta;
		UpdateScore ();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
		restartText.text = "Press 'R' to restart";
	}


	void UpdateScore() 
	{
		scoreText.text = "Score: " + score;
	}
}
