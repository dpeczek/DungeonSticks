using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	NavMeshAgent nav;               // Reference to the nav mesh agent.

	/*void Awake ()
	{

	}*/

	void Start(){
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();
		nav.updateRotation = true;
	}
	
	void Update ()
	{
		//nav.SetDestination (player.position);
		nav.SetDestination (player.position);

	} 

	/// <summary>
	/// Moves to point, where we want to go using Navigator, but end point is 1U closer
	/// </summary>
	/// <param name="targetPosition">Target position.</param>
	private void moveToPoint(Transform targetPosition){

		float distance = Vector3.Distance (transform.position, targetPosition.position);
		if (distance > 3) {
			if (nav.enabled){

			}else{
				nav.enabled=true;
			}
								
		} else {
			nav.enabled=false;
		}

	}
}