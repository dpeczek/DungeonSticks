using UnityEngine;
using System.Collections;

/// <summary>
/// Zatrzymywanie się po przekroczeniu granicy przez gracza
/// </summary>
public class StopOnEngagePlayer : MonoBehaviour {

	#region POLA
	
	private NavMeshAgent agent;
	#endregion
	
	void Awake(){
		agent = GetComponentInParent<NavMeshAgent> ();
	}
	

	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "Player") {
			agent.Stop ();
		}

	}
}
