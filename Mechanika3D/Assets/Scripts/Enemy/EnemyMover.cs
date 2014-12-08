using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	public NavMeshAgent nav;               // Reference to the nav mesh agent.
	Animator anim;                      // Reference to the animator component.

	//Animation booleans
	bool walking = false;
	bool walkAttack=false;
	bool idle=false;
	bool idleAttack=false;

	void Awake ()
	{

		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();
		anim = GetComponentInChildren<Animator> ();
		nav.updateRotation = true;
	}
	
	
	void Update ()
	{
		nav.SetDestination (player.position);
		//player = GameObject.FindGameObjectWithTag ("Player").transform;
		//turnMove ();
	} 

	void FixedUpdate(){
		setAttack ();
		Animating ();

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

	/// <summary>
	/// Checks the distance.
	/// </summary>
	/// <returns>The distance.</returns>
	/// <param name="a">The alpha component.</param>
	/// <param name="b">The blue component.</param>
	private static float checkDistance(Vector3 a, Vector3 b){
		return Vector3.Distance (a, b);
	}

	private void setAttack(){
		if (checkDistance (transform.position, player.position) <= 15) {
			walking = false;
			walkAttack = true;
		} else {
			walking = true;
			walkAttack = false;
		}
	}

	/// <summary>
	/// Animating this instance.
	/// </summary>
	private void Animating(){

		anim.SetBool ("IsWalking", walking);
		anim.SetBool ("IsIdle", idle);
		anim.SetBool ("IsMoveAttack", walkAttack);
		anim.SetBool ("IsIdleAttack", idleAttack);

	}

	private void turnMove(){
		/*float angle = Vector3.Angle (transform.position, player.position);
		float actualAngle = transform.rotation.y;
		if(angle>=20.0)
			transform.Rotate (0.0f, actualAngle+angle, 0.0f);
*/
		float actualAngle = transform.rotation.y;
		transform.Rotate (0.0f, actualAngle+270, 0.0f);
	}
}