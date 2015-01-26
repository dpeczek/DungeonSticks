using UnityEngine;
using System.Collections;

public class planeScript : MonoBehaviour {
	
	public Texture tex1;
	public Texture tex2;
	private int turretsLimit = 10;
	public Texture prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public GameObject prefab3D1;
	public GameObject prefab3D2;
	public GameObject prefab3D3;
	public GameObject prefab3D4;
	public GameObject prefab3D5;
	GameObject prefabClone;
	GameObject prefab3D;
	void CreatePrefabs()
	{

		if (this.gameObject.renderer.material.mainTexture != prefab1 && cameraMove.singleton.getTurrets()<turretsLimit) {
			if(IconScript.number==1 || IconScript.number==2 || IconScript.number==3 || IconScript.number==4 || IconScript.number==5)
			{
				cameraMove.singleton.wavesCount (true);
				this.gameObject.renderer.material.shader = Shader.Find ("Diffuse");
			}
			if (IconScript.number == 1)
				this.gameObject.renderer.material.mainTexture = prefab1;
			if (IconScript.number == 2)
				this.gameObject.renderer.material.mainTexture = prefab1;
			if (IconScript.number == 3)
				this.gameObject.renderer.material.mainTexture = prefab1;
			if (IconScript.number == 4)
				this.gameObject.renderer.material.mainTexture = prefab1;
			if (IconScript.number == 5)
				this.gameObject.renderer.material.mainTexture = prefab1;
		} else {
			/*if (IconScript.number == 5)
			{
				cameraMove.singleton.wavesCount (false);
				this.gameObject.renderer.material.mainTexture = tex1;
				this.gameObject.renderer.material.shader = Shader.Find ("Transparent/Diffuse");
			}*/
		}
		
		if(prefab3D == null && cameraMove.singleton.getTurrets()<turretsLimit) {
			if (IconScript.number == 1)
			{
				Debug.LogWarning("badadadadadadadadadad");
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
			if (IconScript.number == 4)
			{
				prefab3D = (GameObject)Instantiate (prefab3D4, transform.position, transform.rotation);
				prefab3D.SetActive(false);
			}
			if (IconScript.number == 5)
			{
				prefab3D = (GameObject)Instantiate (prefab3D5, transform.position, transform.rotation);
				prefab3D.SetActive(false);
			}

		}
		else {
			/*if (IconScript.number == 5)
				Destroy (prefab3D);*/
		}
	}
	void OnMouseEnter()
	{

		if (this.gameObject.renderer.material.mainTexture != prefab1) {
			this.gameObject.renderer.material.mainTexture = tex2;
			this.gameObject.renderer.material.shader = Shader.Find ("Diffuse");
		}

	}
	void OnMouseExit()
	{
		if (this.gameObject.renderer.material.mainTexture != prefab1) {
			this.gameObject.renderer.material.mainTexture = tex1;
			this.gameObject.renderer.material.shader = Shader.Find ("Transparent/Diffuse");
		}
	}
	void OnMouseDown()
	{
		CreatePrefabs ();
	}
	void Update()
	{
		if(cameraMove.wave && prefab3D==true) prefab3D.SetActive(true);
		if (cameraMove.wave) {

						this.gameObject.renderer.material.mainTexture = tex1;
						this.gameObject.renderer.material.shader = Shader.Find ("Transparent/Diffuse");
				}
		if (Input.GetKey (KeyCode.Delete) && prefab3D != null) {
						cameraMove.singleton.wavesCount (false);
						this.gameObject.renderer.material.mainTexture = tex1;
						this.gameObject.renderer.material.shader = Shader.Find ("Transparent/Diffuse");
						Destroy (prefab3D);
				}
	}
}