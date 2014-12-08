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
	public
	#endregion

	void Awake(){
		spawnPoint = transform.position;
	}

	void Start(){
		StartCoroutine (SpawnWave());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator SpawnWave(){
		yield return new WaitForSeconds(StartWait);
			for(int i=0; i<spawnSize; i++){
				//Spawn gdzieś w pobliżu punktu spawnu 0-2 na x i z 
			Vector3 spawnRealPoint=new Vector3(spawnPoint.x+Random.insideUnitSphere.x * 2,0.0f,spawnPoint.z+Random.insideUnitSphere.z * 2);
				Instantiate (SwordSergeant, spawnRealPoint, transform.rotation);
				yield return new WaitForSeconds(spawnColldown);
			}

		
	}


}
