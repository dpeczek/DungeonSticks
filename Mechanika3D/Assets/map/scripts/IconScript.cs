using UnityEngine;
using System.Collections;

public class IconScript : MonoBehaviour {
	

	//public int is1;
	//public planeScript plab;
	static public int number;

	void Start () {
		//plab = GetComponent<planeScript> ();
		number = 0;
	}
	void OnMouseDown()
	{
		if (gameObject.name.Equals ("Icon1")) {
						number = 1;
						
				}
		if (gameObject.name.Equals ("Icon2")) {
						
						number = 2;
						
				}
		if (gameObject.name.Equals ("Icon3")) {
						number = 3;
				}
		if (gameObject.name.Equals ("Icon4")) {
						number = 4;
				}
	}

	void Update () {


	}
}
