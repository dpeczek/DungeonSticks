using UnityEngine;
using System.Collections;

public class planeScript : MonoBehaviour {

	public Texture tex1;
	public Texture tex2;
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public GameObject prefab3D1;
	public GameObject prefab3D2;
	public GameObject prefab3D3;

	GameObject prefabClone;
	GameObject prefab3D;

	void CreatePrefabs()
	{
		if (prefabClone == null) {
			if (IconScript.number == 1)
				prefabClone = (GameObject)Instantiate (prefab1, transform.position, transform.rotation);
			if (IconScript.number == 2)
				prefabClone = (GameObject)Instantiate (prefab2, transform.position, transform.rotation);
			if (IconScript.number == 3)
				prefabClone = (GameObject)Instantiate (prefab3, transform.position, transform.rotation);
		} else {
			if (IconScript.number == 4)
				Destroy (prefabClone);
		}
		
		if(prefab3D == null) {
			if (IconScript.number == 1)
			{
				prefab3D = (GameObject)Instantiate (prefab3D1, transform.position, transform.rotation);
				prefab3D.SetActive(false);
			}
			if (IconScript.number == 2)
			{
				prefab3D = (GameObject)Instantiate (prefab3D2, transform.position, transform.rotation);
				prefab3D.SetActive(false);
			}
			if (IconScript.number == 3)
			{
				prefab3D = (GameObject)Instantiate (prefab3D3, transform.position, transform.rotation);
				prefab3D.SetActive(false);
			}
		}
		else {
			if (IconScript.number == 4)
				Destroy (prefab3D);
		}
	}
	void Start () {
	}
	void OnMouseEnter()
	{
		this.gameObject.renderer.material.mainTexture = tex2;

	}
	void OnMouseExit()
	{
		this.gameObject.renderer.material.mainTexture = tex1;
	}
	void OnMouseDown()
	{
		CreatePrefabs ();
	}
	void Update()
	{
		if(cameraMove.wave && prefab3D==true) prefab3D.SetActive(true);
	}
}