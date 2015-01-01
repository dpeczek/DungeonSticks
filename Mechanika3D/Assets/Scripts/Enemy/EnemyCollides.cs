using UnityEngine;
using System.Collections;
public class EnemyCollides : MonoBehaviour {

	#region POLA
	public int damage;
	private int turretDamage;
	public int percentageDamage;
	private EnemyHarm sergeant;
	private EnemyMover slowDown;
	private float turretSlow;
	#endregion

	void Awake(){
		sergeant = GetComponentInParent<EnemyHarm> ();
		slowDown = GetComponentInParent<EnemyMover> ();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Magic" || other.tag=="Arrow") {
			if(other.tag=="Arrow")
			{
				this.sergeant.TakeDamage(damage, this.percentageDamage);
			}
			else
			{ 
				sergeant.TakeDamage (damage, 0);
			}
			Destroy (other);
		}
		else if(other.tag == "Bullet")
		{
			this.turretDamage=this.sergeant.basicBulletDamage.damage;
			sergeant.TakeDamage(turretDamage, 0);
			Destroy (other);
		}
		else if(other.tag == "otherBullet")
		{
			this.turretDamage=this.sergeant.otherBulletDamage.damage;
			sergeant.TakeDamage(turretDamage, 0);
			Destroy (other);
		}
		else if(other.tag == "fastBullet")
		{
			this.turretDamage=this.sergeant.fastBulletDamage.damage;
			sergeant.TakeDamage(turretDamage, 0);
			Destroy (other);
		}
		else if(other.tag == "sniperBullet")
		{
			this.turretDamage=this.sergeant.sniperBulletDamage.damage;
			sergeant.TakeDamage(turretDamage, this.percentageDamage);
			Destroy (other);
		}
		else if(other.tag == "sbe")
		{
			this.turretDamage=this.sergeant.slowBulletDamage.damage;
			sergeant.TakeDamage(turretDamage, 0);
			Destroy (other);
		}
		else if(other.tag == "fbe")
		{
			this.turretSlow=this.sergeant.freezingBulletSlow.slow;
			//this.turretDamage=this.sergeant.slowBulletDamage.damage;
			//this.sergeant.TakeDamage(this.turretDamage, 0);
			this.slowDown.slowEnemy(this.turretSlow);
			Destroy (other);
		}

		//TODO: zrobić tak, żeby TYLKO Arrow siekał pół życia
	}
}
