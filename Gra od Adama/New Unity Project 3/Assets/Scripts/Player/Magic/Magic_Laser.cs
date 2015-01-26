using UnityEngine;
using System.Collections;

public class Magic_Laser : MonoBehaviour {

	LineRenderer line;

	// Use this for initialization
	void Start () {
		line=gameObject.GetComponent<LineRenderer>();
		StartCoroutine("FireMagicLaser");
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerable FireMagicLaser()
	{
		Ray ray = new Ray (transform.position, transform.forward);
			
		line.SetPosition(0, ray.origin);
		line.SetPosition(1, ray.GetPoint(100));
		yield return null;
		
		line.enabled=false;
	}
}
