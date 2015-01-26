using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifeTime;

	// Update is called once per frame
	void Update () {
			Destroy (gameObject, lifeTime);
	}
}
