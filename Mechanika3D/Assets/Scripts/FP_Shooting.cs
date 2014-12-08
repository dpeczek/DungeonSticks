using UnityEngine;
using System.Collections;

public class FP_Shooting : MonoBehaviour {

	public GameObject arrow;
	public GameObject magic1;
	public GameObject magic2;
	public float arrowImpulse=60.0f;
	public float fireRate=0.5f;
	public Transform shotSpawnArrow;
	public Transform shotSpawnMagic;

	private float nextFire;
	private string setMagic="magic1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera cam = Camera.main;

		if(Input.GetKeyDown("1"))
		{
			setMagic="magic1";
			//Instantiate(magic1, cam.transform.position, cam.transform.rotation); 
		}
		if(Input.GetKeyDown("2"))
		{
			setMagic="magic2";
			//Instantiate(magic2, cam.transform.position, cam.transform.rotation);
		}
		
		if(Input.GetButton("Fire1") && Time.time>nextFire)
		{
			nextFire=Time.time+fireRate;
			Instantiate(arrow, shotSpawnArrow.transform.position, shotSpawnArrow.transform.rotation);
		}
		if(Input.GetButton("Fire2"))
		{
			if(setMagic=="magic1")
			{
				Instantiate(magic1, shotSpawnMagic.transform.position, shotSpawnMagic.transform.rotation); 
			}
			if(setMagic=="magic2")
			{
				Instantiate(magic2, shotSpawnMagic.transform.position, shotSpawnMagic.transform.rotation); 
			}
		}

	}
}
