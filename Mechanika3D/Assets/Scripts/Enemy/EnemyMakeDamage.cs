using UnityEngine;
using System.Collections;

/// <summary>
/// Klasa zajmująca się robieniem obrażeń głównemu bohaterowi, względnie wieżyczkom
/// </summary>
public class EnemyMakeDamage : MonoBehaviour {

	#region
	public int SwordDamage=10;

	//Metoda komponentu w którego jebniemy obrażeniami
	//private doDPS d;
	#endregion

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//d=other.GetComponent<doDPS>();
			//d.MAKEDAMAGE(50);
		}
	}

}
