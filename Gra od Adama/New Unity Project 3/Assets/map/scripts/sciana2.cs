using UnityEngine;
using System.Collections;

public class sciana2 : MonoBehaviour {
	
	// Use this for initialization

	GameObject camera1=null;
	GameObject planee;
	GameObject wall3=null;
	void Start () {
		camera1 = GameObject.FindGameObjectWithTag("Camera");

		wall3 = GameObject.FindGameObjectWithTag ("wall3");
		wall3.SetActive (false);
		gameObject.renderer.enabled = false;
	}
	void Update()
	{

			
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
						NumerFali.nrfali.setNumer ();
						GameObject[] ad = GameObject.FindGameObjectsWithTag ("Range");
						for (int i=0; i<ad.Length; i++)
								Destroy (ad [i]);
						camera1.SetActive (true);
						cameraMove.singleton.nextWave ();
						wall3.SetActive (true);
						Debug.Log (NumerFali.nrfali.getNumer ().ToString ());
						Destroy (this.gameObject);
				}
	}
}
