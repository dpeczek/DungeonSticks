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
	private Transform aimPosition;


	public int hp=100;

	void Update () 
	{	
		if (myTarget) 
		{
			if(Time.time >= nextMoveTime)
			{
				this.aimPosition=this.myTarget;
				CalculateAimPosition(myTarget.position);
				//II, III
				//head.rotation=Quaternion.Lerp(head.rotation, desiredRotation, Time.deltaTime*turnSpeed);
				//I
				head.LookAt(myTarget);
			}
			
			if(Time.time >= nextFireTime)
			{
				FireProjectile();
			}
			
			if(this.enemyCollider.tag!="Enemy") {
				myTarget=null;
			}
		}
		if (this.hp <= 0) 
		{
			GameObject[] activeBullets=GameObject.FindGameObjectsWithTag("slowBullet");
			foreach(GameObject aB in activeBullets)
			{
				Destroy (aB);
			}
			Destroy (gameObject);
		}

		if (this.hp <= 0) 
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag("slowBullet");
			Slow_bullet[] activeBullets = new Slow_bullet[gos.Length];
			
			for (int i = 0;i < gos.Length;i++)  { 
				activeBullets[i] = gos[i].GetComponent<Slow_bullet>();
			}
			
			foreach(Slow_bullet aB in activeBullets)
			{
				foreach(Slow_bullet bl in myBullets)
				{
					if(bl != null && aB.startingPoint.position == bl.startingPoint.position)
					{	
						Destroy(aB);
					}
				}
			}
			Destroy (gameObject);
		}
	}
	
	void CalculateAimPosition(Vector3 targetPosition)
	{
		//I
		if (targetPosition != null) {
			this.aimPosition.position = new Vector3 (targetPosition.x + aimError, targetPosition.y + aimError, targetPosition.z + aimError);
		}
		//II
		//Vector3 aimPos = new Vector3(targetPosition.x + aimError, targetPosition.y + aimError, targetPosition.z + aimError);
		//desiredRotation = Quaternion.LookRotation(aimPos-ShootPlace.position);
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
			head.LookAt(new Vector3(0,0,0));
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

	public void takeDamage(int damage)
	{
		this.hp -= damage;
	}
}
