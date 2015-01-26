using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 10;
	public Transform startingPoint;

	public int damage=2;

	void Start()
	{
		startingPoint = this.transform;
	}

	void Update () 
	{

		rigidbody.velocity = transform.forward * Time.deltaTime * speed;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{	
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "otherBullet" || other.gameObject.tag == "slowBullet" || other.gameObject.tag == "freezingBullet") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
	
}
