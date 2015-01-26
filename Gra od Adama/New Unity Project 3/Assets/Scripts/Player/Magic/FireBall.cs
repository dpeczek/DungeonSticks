using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public GameObject ExplosionParticleEngine;

	public float speed=10.0f;
	public float rotateAngle=3.0f;
	public float rotateSpeed=5.0f;
	public float maxDistance=20.0f;

	private Vector3 currentPosition;
	// Use this for initialization
	void Start () {
		currentPosition=transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
		//transform.Rotate(transform.position, rotateAngle*rotateSpeed*Time.deltaTime);
	}

	void Move()
	{

	}

	void Explode()
	{
		Instantiate(ExplosionParticleEngine, transform.position, transform.rotation);
		Destroy(gameObject, 1.0f);
	}

	void OnTriggerEnter(Collider other)
	{
		Vector3 explodePosition=transform.position;
		float distance=Mathf.Pow((currentPosition.x-explodePosition.x), 2.0f)+Mathf.Pow((currentPosition.z-explodePosition.z), 2);
		if(other.tag=="Enemy")
		{
			Explode();
		}
		else if(maxDistance==distance)
		{
			Explode();
		}
	}
}
