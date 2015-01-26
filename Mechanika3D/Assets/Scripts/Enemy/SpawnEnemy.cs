using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	#region POLA
	public GameObject SwordSergeant;
	public float spawnColldown=0.5f;//odstęp czasu pomiędzy kolejnym spawnem przeciwnika
	public Vector3 spawnPoint;//punkt w którym nastąpi spawn hordy
	public float StartWait=1.0f;//Początkowe oczekiwanie na rozpoczęcie spawnu
	public float SpawnWait=1.0f;//Początkowe oczekiwanie na rozpoczęcie spawnu
	public int spawnSize=5;//Ile będzie patyczaków
	#endregion

	void Awake(){
		spawnPoint = transform.position;
	}

	void Start(){
        InvokeRepeating("Spawn", 0.3f, spawnSize);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Spawn(){

		 Vector3 spawnRealPoint=new Vector3(spawnPoint.x+Random.insideUnitSphere.x * 2,0.0f,spawnPoint.z+Random.insideUnitSphere.z * 2);
         Instantiate (SwordSergeant, spawnRealPoint, transform.rotation);
		
	}


}
