using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		if (!other.tag.Contains ("Player")) {
			Destroy (other.gameObject);
		}
	}
}
