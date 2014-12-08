using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float mouseSensitivity;
	public float upDownRange;
	public float timeForSlide=1.5f;

	float verticalrotation=0;


	CharacterController characterController;

	//public float health;
	//public float mana;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//rotation
	
		float rotateLeftRight = Input.GetAxis ("Mouse X")*mouseSensitivity;
		transform.Rotate (0, rotateLeftRight, 0);

		verticalrotation -= Input.GetAxis ("Mouse Y")*mouseSensitivity;
		verticalrotation = Mathf.Clamp (verticalrotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalrotation, 0, 0);

		//movement 
		float fowardSpeed = Input.GetAxis ("Vertical")*moveSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal")*moveSpeed;

		Vector3 speed = new Vector3 (sideSpeed, 0, fowardSpeed);

		speed = transform.rotation * speed;

		StartCoroutine (Slide ());
		//cc.SimpleMove (speed);  //only for simple movement no jumps	
		characterController.Move (speed*Time.deltaTime);
	}

	IEnumerator Slide()
	{
		float oldspeed = moveSpeed;
		if(Input.GetKeyDown("space"))
		{
			moveSpeed=oldspeed*25;
			yield return new WaitForSeconds(timeForSlide);
		}
		moveSpeed = oldspeed;
	}
}
