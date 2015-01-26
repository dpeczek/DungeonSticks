using UnityEngine;
using System.Collections;

public class sciana1 : MonoBehaviour {

	// Use this for initialization
	GameObject camera1=null;
	//GameObject playerr;
	GameObject planee;
	GameObject wall2=null;
	void Start () {
		camera1 = GameObject.FindGameObjectWithTag("Camera");
		wall2 = GameObject.FindGameObjectWithTag ("wall2");
		wall2.SetActive (false);
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
						wall2.SetActive (true);
						Debug.Log (NumerFali.nrfali.getNumer ().ToString ());
						Destroy (this.gameObject);
				}
	}
}
