using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion = null;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;


	public void  Start() 
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent<GameController> ();
		
			if (gameController == null) 
			{
				Debug.Log ("Cannot find 'GameController' script");
			}
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Boundary") || other.tag.Contains("Enemy") ) {
			return;
		}
		Debug.Log (other.name);

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
			GetComponent<AudioSource> ().Play ();
		}

		if (other.tag == "Player") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore (scoreValue);

		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}
