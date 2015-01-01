using UnityEngine;
using System.Collections;

public class EnemyHarm : MonoBehaviour {

	public int enemyHealth=100;
	Animator anim;                      // Reference to the animator component.
	EnemyMover mover;
	// Use this for initialization
	
	public Bullet basicBulletDamage; //References to all the bullets that can hit him
	public Bullet otherBulletDamage;
	public Bullet fastBulletDamage;	
	public Bullet sniperBulletDamage;
	public slowBulletExplosionRange slowBulletDamage;
	public freezingBulletExplosionRange freezingBulletSlow;
	private int damage;

	void Awake(){
		anim = GetComponentInChildren<Animator> ();
		mover = GetComponent<EnemyMover> ();
	}


	// Update is called once per frame
	void Update () {
		//Debug.Log("Hp = "+this.enemyHealth);
		if (enemyHealth <= 0) {
			foreach (Transform t in this.transform)
			{
				if(t.name == "EnemyGeneralSword")
				{
					foreach(Transform t2 in t.transform)
					{
						if(t2.name == "Bone_Pelvis")
						{
							foreach(Transform t3 in t2.transform)
							{
								if(t3.name == "Bone_LowerTummy")
								{
									t3.tag="deadEnemy";
								}
							}
						}
					}
				}
			}
			mover.nav.enabled=false;
			anim.SetTrigger("Death");
			Destroy(gameObject,5);
		}
	}

	/// <summary>
	/// Takes the damage	/// </summary>
	/// <param name="damage">Obrażenia jakie przyjmie (o ile wystąpią)</param>
	/// <param name="perceantage">Procentowe jebnięcie (o ile wystąpi)</param>
	public void TakeDamage(int damage, int perceantage){
		enemyHealth -= damage;
		enemyHealth -= (enemyHealth * perceantage);
		Debug.Log("d: " +damage + " p: "+ perceantage +" Hp = "+this.enemyHealth);
	}
}
