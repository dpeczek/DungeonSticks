using UnityEngine;
using System.Collections;

public class healthPoints : MonoBehaviour {


	public int hp=10;
	public Bullet basicBulletDamage;
	public Bullet otherBulletDamage;
	private int damage=2;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet") {	
			damage = basicBulletDamage.damage;
			hp = hp - damage;
		} 
		else if (other.gameObject.tag == "otherBullet") {
			damage = otherBulletDamage.damage;
			hp = hp - damage;
		}
	}

	void Update () {
		if (hp <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
