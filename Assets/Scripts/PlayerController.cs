using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb; 
	public int speed; 
	public int tilt; 
	public Boundary boundary; 
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	[System.Serializable]
	public class Boundary {
		public int xMin, xMax, zMin, zMax;
	}

	void Start() {
		rb = GetComponent<Rigidbody> ();

	}

	void Update() {

		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

			// create code here that animates the newProjectile        

			nextFire = Time.time + fireRate;
			GetComponent<AudioSource>().Play ();

		}
	}

	// Use this for initialization
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		//adding banking;
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
	

}
