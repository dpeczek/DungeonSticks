using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	#region POLA
	public GameObject SwordSergeant;
    public GameObject SwordPrivate;
	public float spawnColldown=0.5f;//odstęp czasu pomiędzy kolejnym spawnem przeciwnika
	private Vector3 spawnPoint;//punkt w którym nastąpi spawn hordy
	public float StartWait=1.0f;//Początkowe oczekiwanie na rozpoczęcie spawnu
	public float SpawnWait=1.0f;//Początkowe oczekiwanie na rozpoczęcie spawnu
    public int waveSize = 1;//Ile będzie fal
	public int spawnSize=5;//Ile będzie patyczaków
	#endregion

	void Awake(){
		spawnPoint = transform.position;
        StartCoroutine("Spawn");
	}

	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Spawn(){
        Vector3 spawnRealPoint;
        for (int i = 0; i < waveSize; i++)
        {
			Debug.Log("Spawnuję falę");
            for (int j = 0; j < spawnSize; j++)
            {
				Debug.Log("Spawnuję patyczaka");
                spawnRealPoint = new Vector3(spawnPoint.x + Random.insideUnitSphere.x * 2, 0.0f, spawnPoint.z + Random.insideUnitSphere.z * 2);

                if (Random.Range(0, 100) <= 75)
                {
                    Instantiate(SwordPrivate, spawnRealPoint, transform.rotation);
                }
                else
                {
                    Instantiate(SwordSergeant, spawnRealPoint, transform.rotation);
                }
                yield return new WaitForSeconds(SpawnWait);
            }

            Debug.Log("Koniec fali " + (i + 1));
            yield return new WaitForSeconds(10);
        }


        
	}


}
