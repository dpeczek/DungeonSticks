using UnityEngine;
using System.Collections;

public class NumerFali : MonoBehaviour {

	// Use this for initialization
	static public NumerFali nrfali = null;
	private int numer_fali=1;
	public void setNumer()
	{
				numer_fali++;
		}
	public int getNumer()
	{
				return numer_fali;
		}
	void Start () {
		nrfali = new NumerFali ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
