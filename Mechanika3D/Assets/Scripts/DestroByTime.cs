using UnityEngine;
using System.Collections;

public class DestroByTime : MonoBehaviour {
	public float lifeTime=5.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
