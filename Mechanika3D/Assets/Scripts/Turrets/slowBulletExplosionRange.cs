using UnityEngine;
using System.Collections;

public class slowBulletExplosionRange : MonoBehaviour {
	
	public Transform startingPoint;
	
	public int damage=25;
	
	void Start()
	{
		startingPoint = this.transform;
	}
	
	void Update () 
	{

	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{	
			Destroy (this.gameObject);
		}
	}
}
