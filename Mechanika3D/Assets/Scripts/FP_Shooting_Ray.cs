using UnityEngine;
using System.Collections;

public class FP_Shooting_Ray : MonoBehaviour {

	public GameObject HitPointParticlePrefab;
	public Transform SpawnPointMagic;
	public GameObject MagicalPrefab;
	public GameObject FireballPrefab;
	public GameObject IceWallPrefab;
	public float range=100f;

	public float cooldownCrossbow=0.1f;
	public float cooldownMagical;
	public float cooldownFireBall=2.0f;
	public float cooldownIceWall;
	
	float cooldownRemaining=0;
	private string setMagic="magical";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		CheckInput();
	}

	void CheckInput()
	{
		if(Input.GetKeyDown("1"))
		{
			setMagic="magical";
			//Instantiate(magic1, cam.transform.position, cam.transform.rotation); 
		}
		
		if(Input.GetKeyDown("2"))
		{
			setMagic="fireball";
			//Instantiate(magic2, cam.transform.position, cam.transform.rotation);
		}
		
		if(Input.GetKeyDown("3"))
		{
			setMagic="iceWall";
		}
		
		if(Input.GetButton("Fire1") && cooldownRemaining<=0)
		{
			cooldownRemaining=cooldownCrossbow;
			Ray ray =new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo=new RaycastHit();
			if(Physics.Raycast(ray, out hitInfo, range))
			{
				Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
				Vector3 hitPoint=hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				Debug.Log("hitPoint: "+hitPoint +"hitObject: " + go.name);
				if(go.tag=="Enemy")
				{
					EnemyHarm health = go.GetComponent<EnemyHarm>();
					health.TakeDamage(50, 100);
				}
				//Instantiate(CrossbowShootParticle, //dodac flasz przy kuszy
				//Instantiate(HitPointParticlePrefab, hitPoint, Quaternion.identity);
			}
		}
		
		if(Input.GetButton("Fire2"))
		{
			if(setMagic=="magical")
			{
				 //TODO Lepiej ustawić to tutaj czy gdzie indziej, te niby magię
			}
			
			if(setMagic=="fireball" && cooldownRemaining<=0)
			{
				cooldownRemaining=cooldownFireBall;
				Instantiate(FireballPrefab, SpawnPointMagic.transform.position, SpawnPointMagic.transform.rotation);
				//TODO tworzenie fireballa po odpowiednim czasie i odjęcie od many
			}
			
			if(setMagic=="iceWall" && cooldownRemaining<=0)
			{
				cooldownRemaining=cooldownIceWall;
				//TODO tworzenie lodowego muru po odpowiednim czasie i odjęcie od many( instancjonowanie na stałej odległości)
			}
		}
	}
}
