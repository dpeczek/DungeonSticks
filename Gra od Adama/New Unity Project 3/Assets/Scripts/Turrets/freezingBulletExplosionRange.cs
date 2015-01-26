using UnityEngine;
using System.Collections;

public class freezingBulletExplosionRange : MonoBehaviour {

	public Transform startingPoint;
	
	public float slow=0.5f;
	
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
