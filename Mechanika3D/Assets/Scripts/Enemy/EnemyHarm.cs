using UnityEngine;
using System.Collections;

public class EnemyHarm : MonoBehaviour {

	public int enemyHealth=100;
	Animator anim;                      // Reference to the animator component.
	EnemyMover mover;
	// Use this for initialization
	void Awake(){
		anim = GetComponentInChildren<Animator> ();
		mover = GetComponent<EnemyMover> ();
	}


	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
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
	}
}
