using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	public NavMeshAgent nav;               // Reference to the nav mesh agent.
	Animator anim;                      // Reference to the animator component.

	public float speed = 40;
	public float slowValue = 1;
	private bool isSlowed = false;
	private int slowCount = 0;
	//private int counter=0; //zlicza ilość stunów

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
		nav.angularSpeed = 15;
	}
	
	
	void Update ()
	{	
		if (nav.enabled == true) {
			nav.SetDestination (player.position);
		}
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


	public void slowEnemy(float slow)
	{
		float tmpSlow = this.slowValue;
		if (this.slowCount >= 10 & isSlowed) { //stun gdy 10x z zrzędu oberwie z freezingTurreta w stanie zamrożenia (czyli w trakcie tych 5sec przedłużanych o kolejne trafienia - statystycznie i w praktyce trudne do osiągnięcia :D)
			//nav.Stop(true);
			//this.stunTime(3);
			this.slowCount = 0;
			//this.counter+=1; //zliczanie ilosci stunów
		} else {
			this.slowValue = slow;
		}
		nav.speed = this.speed * this.slowValue;
		this.isSlowed = true;
		this.slowCount += 1;
		this.slowTime(5, tmpSlow);
		//Debug.Log ("Speed: " + nav.speed + ".");
		//Debug.Log ("Counter: " + this.slowCount); //info o ilosci udanych stunów
	}

	IEnumerator slowTime(float duration, float tmpSlow)
	{

		yield return new WaitForSeconds(duration);   //Wait
		this.slowValue = tmpSlow;
		this.isSlowed = false;
		this.slowCount = 0;
	}

	IEnumerator stunTime(float duration)
	{
		yield return new WaitForSeconds (duration);
		this.nav.Resume();
	}
}