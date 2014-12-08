using UnityEngine;
using System.Collections;

public class prefabSript : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(cameraMove.wave) Destroy(this.gameObject);
	}
}
