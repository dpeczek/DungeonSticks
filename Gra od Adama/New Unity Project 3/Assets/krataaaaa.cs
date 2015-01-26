using UnityEngine;
using System.Collections;

public class krataaaaa : MonoBehaviour {

	// Use this for initialization
	private bool ruch=false;
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
		if(ruch) this.gameObject.transform.Translate (Vector3.right * 20 * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		GameObject[] ad = GameObject.FindGameObjectsWithTag ("patyczak");
				if (other.gameObject.tag != "Player" && ad.Length==0) {
					ruch = true;
						
				}
		}
						
}
