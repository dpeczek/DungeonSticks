using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour {

	// Use this for initialization
	GameObject map;
	GameObject plane;
	GameObject player;
	public GameObject prefabPlane;
	public GameObject prefabMap;
	static public bool wave = false;
	public GameObject prefabPlayer;
	void Start () {	
		plane = (GameObject)Instantiate (prefabPlane);
		plane.SetActive(false);
		map = (GameObject)Instantiate(prefabMap);
		transform.position = new Vector3 (0, 250, -20);
		transform.localEulerAngles = new Vector3(90,0,0);
		player = (GameObject)Instantiate (prefabPlayer);
		player.SetActive (false);
	}
	void Update () 
	{
		if (Input.GetKey (KeyCode.H))
						wave = true;
		if (wave){
						plane.SetActive (true);
						player.SetActive(true);
						Destroy (map.gameObject);
						Destroy (this.gameObject);
				}
				
	}
}