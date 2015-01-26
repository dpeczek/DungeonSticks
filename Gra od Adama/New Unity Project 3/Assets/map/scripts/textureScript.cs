using UnityEngine;
using System.Collections;

public class textureScript : MonoBehaviour {

	// Use this for initialization
	public Sprite newSprite;
	public Sprite newSprite1;
	public Sprite newSprite2;
	public Sprite newSprite3;
	public Sprite newSprite4;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(IconScript.number==1)  GetComponent<SpriteRenderer> ().sprite = newSprite;
		if(IconScript.number==2)  GetComponent<SpriteRenderer> ().sprite = newSprite1;
		if(IconScript.number==3)  GetComponent<SpriteRenderer> ().sprite = newSprite2;
		if(IconScript.number==4)  GetComponent<SpriteRenderer> ().sprite = newSprite3;
		if(IconScript.number==5)  GetComponent<SpriteRenderer> ().sprite = newSprite4;
	}
}
