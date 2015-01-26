using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class freezingTurret : MonoBehaviour {
	
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
	
	private List<freezingBullet> myBullets = new List<freezingBullet> ();
	private freezingBullet myTmpBullet;
	private freezingBullet bull;
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
				head.LookAt(aimPosition);
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
			GameObject[] gos = GameObject.FindGameObjectsWithTag("freezingBullet");
			freezingBullet[] activeBullets = new freezingBullet[gos.Length];
			
			for (int i = 0;i < gos.Length;i++)  { 
				activeBullets[i] = gos[i].GetComponent<freezingBullet>();
			}
			
			foreach(freezingBullet aB in activeBullets)
			{
				foreach(freezingBullet bl in myBullets)
				{
					if(bl != null && aB.startingPoint.position == bl.startingPoint.position)
					{	
						Destroy(aB);
					}
				}
			}
			foreach (Transform t in this.transform)
			{
				if(t.name == "Temperature")
				{
					t.tag="Neutral";
				}
			}
			Destroy (gameObject);
		}
	}
	
	void CalculateAimPosition(Vector3 targetPosition)
	{	
		if (targetPosition != null) {
			this.aimPosition.position = new Vector3 (targetPosition.x + aimError, targetPosition.y + aimError, targetPosition.z + aimError);
		}
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
				myTmpBullet=tmp.GetComponent<freezingBullet>();
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
		if (other.gameObject.tag == "freezingBullet") 
		{	
			if (other.gameObject != null)
			{	
				this.bull=other.gameObject.GetComponent<freezingBullet>();
				
				foreach(freezingBullet bl in myBullets)
				{
					if(hp>0 && bl != null && bull.startingPoint.position == bl.startingPoint.position)
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
