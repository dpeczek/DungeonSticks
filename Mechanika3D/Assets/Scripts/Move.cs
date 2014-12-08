using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public float speed = 10;

	private bool notInCollison=true;


	void Update () 
	{	
		if (notInCollison) 
		{
			rigidbody.velocity = transform.forward * Time.deltaTime * speed;
		} 
		else
		{
			rigidbody.velocity = transform.right * Time.deltaTime * speed;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Turret") 
		{
			notInCollison = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag== "Turret")
		{
			notInCollison = true;
		}
	}
}
