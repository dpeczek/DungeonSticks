using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//Referencja do obiektu gracza
	public GameObject player;
	//Przesunięcie kamery względem pozycji gracza
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
