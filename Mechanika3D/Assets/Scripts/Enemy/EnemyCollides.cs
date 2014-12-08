using UnityEngine;
using System.Collections;
public class EnemyCollides : MonoBehaviour {

	#region POLA
	public int damage;
	public int percentageDamage;
	private EnemyHarm sergeant;
	#endregion

	void Awake(){
		sergeant = GetComponentInParent<EnemyHarm> ();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Bullet" || other.tag == "otherBullet" || other.tag == "Magic" || other.tag=="Arrow") {
			sergeant.TakeDamage (damage, percentageDamage);
		}

		//TODO: zrobić tak, żeby TYLKO Arrow siekał pół życia
	}
}
