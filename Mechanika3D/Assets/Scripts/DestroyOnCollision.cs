using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public GameObject explosion;

	void OnzEnter(Collider other)
	{
		if (other.tag == "Enemy") 
		{
			Destroy (gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
		}

	}
}
