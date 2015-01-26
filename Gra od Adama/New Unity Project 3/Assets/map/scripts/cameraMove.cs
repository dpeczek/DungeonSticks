using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour {

	public static cameraMove singleton = null;
	GameObject map=null;
	GameObject map2=null;
	GameObject map3=null;
	GameObject map4=null;
	GameObject plane=null;
	GameObject pref=null;
	//GameObject ahg= null;
	public GameObject prefabMap;
	public GameObject prefabMap2;
	public GameObject prefabMap3;
	public GameObject prefabMap4;
	static public bool wave = false;


	//public GameObject prefabPlayer;
	private int turrets=0;
	public int getTurrets()
	{
				return turrets;
	}
	public void wavesCount(bool symbol)
	{
				if (symbol)
						turrets++;
				else
						turrets--;
				Debug.Log (turrets);
		}
	void Start () {
	
		pref = GameObject.FindGameObjectWithTag ("Player");
		pref.SetActive (false);
		plane = GameObject.FindGameObjectWithTag ("plane");
		plane.SetActive (false);
		singleton = new cameraMove ();
		map = (GameObject)Instantiate (prefabMap);
		transform.position = new Vector3 (0, 200, 0);
		transform.localEulerAngles = new Vector3 (90, 0, 0);
		Debug.Log ("start");

	}
	public void nextWave()
	{
		singleton = new cameraMove ();
		Debug.Log ("waves54");
				pref = GameObject.FindGameObjectWithTag ("Player");
				pref.SetActive (false);
				plane = GameObject.FindGameObjectWithTag ("plane");
				plane.SetActive (false);
				
				//map = (GameObject)Instantiate (prefabMap);
				//transform.position = new Vector3 (0, 200, 0);
				//transform.localEulerAngles = new Vector3 (90, 0, 0);
	}
	void Update () 
	{
		//if(singleton==null)singleton = new cameraMove ();
		/*Renderer[] rs1 = map.GetComponentsInChildren<Renderer>();
		foreach (Renderer r1 in rs1)
		{
			r1.enabled = true;
		}*/
	
		//ahg = GameObject.FindGameObjectWithTag ("wall1");
		if (map2 == null && NumerFali.nrfali.getNumer()==2) {
						Debug.Log("map2");
						map2 = (GameObject)Instantiate (prefabMap2);
						transform.position = new Vector3(106,278,83);
						transform.localEulerAngles = new Vector3(90,0,0);
				}
		if (map3 == null && NumerFali.nrfali.getNumer()==3) {
			Debug.Log("map3");
			map3 = (GameObject)Instantiate (prefabMap3);
			transform.position = new Vector3(-83,110,251);
			transform.localEulerAngles = new Vector3(90,0,0);
		}
		if (map4 == null && NumerFali.nrfali.getNumer()==4) {
			Debug.Log("map4");
			map4 = (GameObject)Instantiate (prefabMap4);
			transform.position = new Vector3(85,250,251);
			transform.localEulerAngles = new Vector3(90,0,0);
		}
		if (startScript.x)
								wave = true;
						else
								wave = false;
						if (startScript.x) 
						{
										pref.SetActive (true);
										plane.SetActive (true);
								
								
								startScript.but.setX ();
								if(map)Destroy(map.gameObject);
								if(map2)Destroy(map2.gameObject);
								if(map3)Destroy(map3.gameObject);
								if(map4)Destroy(map4.gameObject);
								/*	Renderer[] rs = map.GetComponentsInChildren<Renderer>();
								foreach (Renderer r in rs)
								{
									r.enabled = false;
								}*/
								this.gameObject.SetActive(false);
								//wave = false;
						
						}
						

				
	}
}