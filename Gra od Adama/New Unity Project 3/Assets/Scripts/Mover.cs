using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float moveSpeed=10.0f;


	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
