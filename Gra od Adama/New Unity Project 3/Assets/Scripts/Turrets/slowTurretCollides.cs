using UnityEngine;
using System.Collections;

public class slowTurretCollides : MonoBehaviour {
	
	
	public int damagePrivate=5;
	public int damageGeneral=15;
	private slowTurret fT;
	// Use this for initialization
	void Start () {
		this.fT = GetComponentInParent<slowTurret> ();
	}
	
	
	void OnTriggerEnter(Collider other){
		//Debug.Log ("Collider: " + other.tag);
		if (other.tag == "Magic") 
		{
			
		} 
		else if (other.tag == "MieczPrivate") 
		{
			this.fT.takeDamage(this.damagePrivate);
			Debug.Log ("Hp turret: " + this.fT.hp + ".");
		}
		else if (other.tag == "MieczGeneral") 
		{
			this.fT.takeDamage(this.damageGeneral);
			Debug.Log ("Hp turret: " + this.fT.hp + ".");
		}
	}
	
}
