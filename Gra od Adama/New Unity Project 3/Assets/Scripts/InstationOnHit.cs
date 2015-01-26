using UnityEngine;
using System.Collections;

public class InstationOnHit : MonoBehaviour {

	public GameObject instation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionExit()
	{
		Instantiate (instation, transform.position, transform.rotation);
	}
}
