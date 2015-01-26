using UnityEngine;
using System.Collections;

public class freezingBullet : MonoBehaviour {

	
	public float speed = 10;
	public Transform startingPoint;
	public GameObject freezingBulletExplosionRange;
	private Vector3 explosionPlace;
	
	public int damage=0;
	
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
			this.explosionPlace=new Vector3(other.transform.position.x, 0, other.transform.position.z);
			Instantiate(this.freezingBulletExplosionRange, this.explosionPlace, other.transform.rotation);
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "otherBullet" || other.gameObject.tag == "slowBullet" || other.gameObject.tag == "freezingBullet") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
