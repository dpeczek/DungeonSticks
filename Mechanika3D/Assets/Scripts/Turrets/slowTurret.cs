using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class slowTurret : MonoBehaviour {
	
	public Transform myTarget;
	public GameObject myBullet;
	public float turnSpeed=5.0f;
	public float reloadTime = 1.0f;
	public float firePauseTime = 0.0f;
	public float errorAmount = 0.0f;
	public Transform[] muzzlePosition;
	public GameObject muzzleEffect;
	public Transform head;
	public Transform ShootPlace;
	
	private List<Slow_bullet> myBullets = new List<Slow_bullet> ();
	private Slow_bullet myTmpBullet;
	private Slow_bullet bull;
	private float nextFireTime;
	private float nextMoveTime;
	private Quaternion desiredRotation; 
	private float aimError;
	private Collider enemyCollider;
	
	void Update () 
	{	
		if (myTarget) 
		{
			if(Time.time >= nextMoveTime)
			{
				CalculateAimPosition(myTarget.position);
				head.rotation=Quaternion.Lerp(head.rotation, desiredRotation, Time.deltaTime*turnSpeed);
			}
			
			if(Time.time >= nextFireTime)
			{
				FireProjectile();
			}
			
			if(this.enemyCollider.tag!="Enemy") {
				myTarget=null;
			}
		}
	}
	
	void CalculateAimPosition(Vector3 targetPosition)
	{
		Vector3 aimPos = new Vector3(targetPosition.x + aimError, targetPosition.y + aimError, targetPosition.z + aimError);
		desiredRotation = Quaternion.LookRotation(aimPos-ShootPlace.position);
	}
	
	void CalculateAimError()
	{
		aimError = Random.Range (-errorAmount, errorAmount);
	}
	
	void FireProjectile()
	{
		audio.Play();
		nextFireTime = Time.time + reloadTime;
		nextMoveTime = Time.time + firePauseTime;
		CalculateAimError ();
		foreach(Transform theMuzzlePos in muzzlePosition)
		{
			GameObject tmp=Instantiate(myBullet, theMuzzlePos.position, theMuzzlePos.rotation) as GameObject;
			Instantiate(muzzleEffect, theMuzzlePos.position, theMuzzlePos.rotation);
			if(tmp!= null)
			{
				myTmpBullet=tmp.GetComponent<Slow_bullet>();
				//myTmpBullet.startingPoint=theMuzzlePos;
				myBullets.Add(myTmpBullet);
			}
		}
	}
	
	
	void OnTriggerStay(Collider other)
	{	
		if (!myTarget) {
			if (other.gameObject.tag == "Enemy") {
				StartCoroutine (rememberEnemy(other));
				nextFireTime = Time.time + (reloadTime * 0.5f);
				myTarget = other.gameObject.transform;
			}
		}
	}
	
	IEnumerator rememberEnemy (Collider other) {
		this.enemyCollider = other;
		yield return null;
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform == myTarget) 
		{	
			myTarget = null;
		} 
		if (other.gameObject.tag == "slowBullet") 
		{	
			if (other.gameObject != null)
			{	
				this.bull=other.gameObject.GetComponent<Slow_bullet>();

				foreach(Slow_bullet bl in myBullets)
				{
					if(bl != null && bull.startingPoint.position == bl.startingPoint.position)
					{	
						Destroy(other.gameObject);
					}
				}
			}
			
		}
	}	
}
