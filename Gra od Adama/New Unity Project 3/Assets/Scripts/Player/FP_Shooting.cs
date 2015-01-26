using UnityEngine;
using System.Collections;
using UnityEngineInternal;

public class FP_Shooting : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public GameObject MagicalPrefab;
    public GameObject FireballPrefab;
    public GameObject IceWallPrefab;

    public Transform SpawnPointMagic;
    public Transform shotSpawnArrow;

    public float cooldownCrossbow = 0.1f;
    public float cooldownMagical;
    public float cooldownFireBall = 20.0f;
    public float cooldownIceWall = 30.0f;

    private float cooldownRemaining = 0;

    private string setMagic = "magical";

    bool fire1;
    bool fire2;

    private bool hasCrossbow = false;

    //stany animacji
    private int endMagicHash = Animator.StringToHash("");

    Animator anim;
    private PlayerMana playerMana;
    // Use this for initialization

    void SetCrossbow(bool state)
    {
        hasCrossbow = state;
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerMana = GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownRemaining -= Time.deltaTime;
        Camera cam = Camera.main;
        CheckInput();
        Animate();
    }

    void CheckInput()
    {
        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown("1"))
        {
            setMagic = "magical";
        }

        if (Input.GetKeyDown("2"))
        {
            setMagic = "fireball";
        }

        if (Input.GetKeyDown("3"))
        {
            setMagic = "iceWall";
        }
        if (Input.GetButton("Fire1")) fire1 = true;
        else fire1 = false;

        if (Input.GetButton("Fire2")) fire2 = true;
        else fire2 = false;

        if (Input.GetKeyDown("h"))
        {
            if (hasCrossbow == true)
            {
                SetCrossbow(false);
            }
            if (hasCrossbow == false)
            {
                SetCrossbow(true);
            }
        }

        if (hasCrossbow == true)
        {
            if (fire1 && cooldownRemaining <= 0 && !fire2 )
            {
                cooldownRemaining = cooldownCrossbow;
                Instantiate(ArrowPrefab, shotSpawnArrow.transform.position, shotSpawnArrow.transform.rotation);
            }

            if (Input.GetMouseButton(1))
            {
                if (setMagic == "magical" && cooldownMagical <= 0)
                {
                    if (playerMana.SubtractMana(5))
                    {
                        anim.SetBool("UseMagicC", true);
                        Instantiate(ArrowPrefab, SpawnPointMagic.transform.position, SpawnPointMagic.transform.rotation);
                    }
                }

                if (setMagic == "fireball" && cooldownRemaining <= 0)
                {
                    if (playerMana.SubtractMana(50))
                    {
                        cooldownRemaining = cooldownFireBall;
                        Instantiate(FireballPrefab, SpawnPointMagic.transform.position, SpawnPointMagic.transform.rotation);
                    }
                    //TODO tworzenie fireballa po odpowiednim czasie i odjęcie od many
                }

                if (setMagic == "iceWall" && cooldownRemaining <= 0)
                {
                    if (playerMana.SubtractMana(60))
                    {
                        cooldownRemaining = cooldownIceWall;
                    }
                    //TODO tworzenie lodowego muru po odpowiednim czasie i odjęcie od many( instancjonowanie na stałej odległości)
                }
            }
            else
            {

                anim.SetBool("UseMagicC", false);
                //fire2 = false;
            }
        }
        else if (hasCrossbow == false)
        {
            if (Input.GetMouseButton(1))
            {
                if (setMagic == "magical")
                {
                    if (playerMana.SubtractMana(5))
                    {
                        anim.SetBool("UseMagicWC", true);
                        Instantiate(ArrowPrefab, shotSpawnArrow.transform.position, shotSpawnArrow.transform.rotation);
                    }
                    //StartCoroutine(SimpleCoolDown(1.5f));
                    //Instantiate(FireballPrefab, SpawnPointMagic.transform.position, SpawnPointMagic.transform.rotation);
                }

                if (setMagic == "fireball" && cooldownRemaining <= 0)
                {
                    if (playerMana.SubtractMana(50))
                    {
                        cooldownRemaining = cooldownFireBall;
                        Instantiate(FireballPrefab, SpawnPointMagic.transform.position, SpawnPointMagic.transform.rotation);
                    }
                    //TODO tworzenie fireballa po odpowiednim czasie i odjęcie od many
                }

                if (setMagic == "iceWall" && cooldownRemaining <= 0)
                {
                    if (playerMana.SubtractMana(60))
                    {
                        cooldownRemaining = cooldownIceWall;
                    }
                    //TODO tworzenie lodowego muru po odpowiednim czasie i odjęcie od many( instancjonowanie na stałej odległości)
                }
            }
            else
            {

                anim.SetBool("UseMagicWC", false);
                //fire2 = false;
            }
        }
        
    }

    void Animate()
    {
        if (fire1)
        {
            anim.SetBool("IsShooting", true);
        }
        else
        {
            anim.SetBool("IsShooting", false);
        }

        if (Input.GetKeyDown("q") && hasCrossbow == true)
        {
            anim.SetTrigger("UseSwordC");
        }
        else if (Input.GetKeyDown("q") && hasCrossbow == false)
        {
            anim.SetTrigger("UseSwordWC");
        }
    }

    IEnumerator SimpleCoolDown(float time)
    {
        yield return new WaitForSeconds(time);
    }
}