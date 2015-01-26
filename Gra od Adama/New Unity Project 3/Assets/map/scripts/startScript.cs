using UnityEngine;
using System.Collections;

public class startScript: MonoBehaviour {
	
	// Use this for initialization
	public static startScript but;
	public static bool x;
	public void setX()
	{
		x = false;
	}
	void Start () {
		but = new startScript ();
		x = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnMouseDown()
	{
		//Cam.SetActive(true);
		x = true;
	}
	
	
}