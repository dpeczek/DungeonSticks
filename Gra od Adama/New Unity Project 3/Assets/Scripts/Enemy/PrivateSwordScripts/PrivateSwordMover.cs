using UnityEngine;
using System.Collections;
using Assets.Scripts.Enemy.SpawningScripts;
public class PrivateSwordMover : MonoBehaviour {

    #region POLA
    public NavMeshAgent nav;               // Reference to the nav mesh agent.
    Animator anim;                      // Reference to the animator component.

    public float slowValue = 1;
    private bool isSlowed = false;
    private int slowCount = 0;
    private float acc;
    //private int counter=0; //zlicza ilość stunów


    /// <summary>
    /// Cel do którego ma poruszać się nasz patyczak
    /// </summary>
    GameObject target;


    GameObject range;//wiezyczka
    /// <summary>
    /// Drzwi, które patyczak musi zniszczyć, żeby się wydostać
    /// </summary>
    GameObject exit;

    //Referencja do playera
    GameObject player;

    //Referencja do wszystkich wieżyczek
    TurretPositions turretsList;

    //Referencja do pojedynczej wieżyczki
    TurretType turretPoint;

    public bool Moving { get; set; }

    private bool walk;
    private bool attack;
    private bool attackIdle;



    //Boolowskie wartości określające, gdzie patyczak się kieruje
    bool portal = false;
    bool turret = false; //Portal lub wieżyczka
    bool human = false;//Człowiek

    //Boolowska zmienna określająca, czy patyczak został zaatakowany
    public bool isAttacked = false;

    public bool IsAttacked
    {
        set { isAttacked = value; }
        get { return isAttacked; }
    }

    //Zmienna określająca czy patyczak zdecydował co robi
    bool moveDecide = false;
    bool IsTurrets = true;
    #endregion



    void Awake()
    {

        //TODO: Przerobić Turret, by wykorzystywało informacje zawarte w TurretPositions
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player"); //To się na bieżąco aktualizuje

        exit = GameObject.FindGameObjectWithTag("Portal");//Portal wyjściowy


        range = GameObject.FindGameObjectWithTag("Range");
        //Pobranie listy wieżyczek - WAŻNE, ŻEBY NIE PRACOWAĆ bezpośrednio na tej liście, bo może dojść do niechcianego zakleszczenia - przynajmniej tak mi się wydawało na początku
        //turretsList = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<TurretPositions>();
        // turretPoint = turretsList.TurretsList[0];

        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Moving = true;
        nav.updatePosition = true;
        nav.updateRotation = true;
        this.acc = this.nav.acceleration;
        nav.SetDestination(exit.transform.position);
        StartCoroutine("decideMove");
    }



    void Update()
    {
        if (range == null && IsTurrets)
        {
            range = GameObject.FindGameObjectWithTag("Range");
            if (range == null)
            {

            }
            IsTurrets = false;
        }
        /* if (turretPoint.Turret=null)
         {
             Debug.Log("Nie wiem gdzie iść");
             turretsList.TurretsList.Remove(turretPoint);
             if(turretsList.TurretsList.Count>0)
                 turretPoint = turretsList.TurretsList[0];
            
         }*/

        if (!Moving)
        {
            nav.enabled = false;
            //Invoke("MoveTurret", 0.3f);
            /*target = player;
            Invoke("MovePlayer", 0.3f);*/
            /*if (portal)
            {
                Invoke("MoveTurret", 0.3f);
            }
            if (turret)
            {
                Invoke("MoveTurret", 0.3f);
            }
            else
            {
                Invoke("MovePlayer", 0.3f);
            }*/
            /* Invoke("decideMove", 0.3f);

             Invoke("changeBrain",2.0f);*/

        }
        else
        {

        }
    }

    void FixedUpdate()
    {
        Animating();
    }



    /// <summary>
    /// Metoda odpowiada za decydowanie o aktualnym celu patyczaka nieboraka
    /// </summary>
    IEnumerator decideMove()
    {
        int brainIterator = 0;//Magiczny iterator, który 
        while (true)
        {
            if (nav.enabled == false)
                break;
            if ((human == true || turret == true) && brainIterator < 10)
            {
                brainIterator++;
                yield return new WaitForSeconds(0.3f);   //Wait
                continue;
            }
            else
            {
                brainIterator = 0;
                human = false;
                turret = false;
            }

            if (checkPlayer() == false && checkTurret() == false && IsAttacked == false)
            {
                Debug.Log("NA PORTAL");
                target = exit;
                //MoveTurret();
                Invoke("MoveTurret", 1.0f);
            }
            else

                //Jeśli gracz jest blisko
                if (IsAttacked == true || checkPlayer())
                {
                    int los = losuj();
                    if (los < 70)
                    {
                        human = true;
                        Debug.Log("NA GRACZA");
                        target = player;
                        //MovePlayer();
                        Invoke("MovePlayer", 1.0f);
                    }
                    else
                    {
                        Debug.Log("NA PORTAL Z ATAKU GRACZA");
                        //Uznaj, że cię nie atakowano
                        IsAttacked = false;
                        target = exit;
                        //MoveTurret();
                        Invoke("MoveTurret", 1.0f);
                    }

                }

            if (checkTurret())
            {
                turret = true;
                Debug.Log("NA TURRETA");
                //Uznaj, że cię nie atakowano
                target = range;
                //MoveTurret();
                Invoke("MoveTurret", 1.0f);

            }




            yield return new WaitForSeconds(3.0f);   //Wait
        }


        //Jeśli patyczak jest niezdecydowany to
        /* if (!moveDecide)
         {
             moveDecide = true;*/
        //Jeśli nic cię nie rozprasza idź na wieżyczkę




        //}






        /*
        //Kiedy patyczak jest niezdecydowany
        if(!moveDecide)
        {
            moveDecide = true;

            //Losuj czy idziesz na portal, czy na przeciwnika
            int los = (int)Random.Range(0.0f, 1000.0f);
            Debug.Log("Wylosowano: " + los);
            if (los < 600)
            {
                portal = true;
                turret = false;
                human = false;
                target = exit;
            }
            if (los >= 600 && los < 900)
            {
                portal = false;
                turret = true;
                human = false;
                target = turrets[iteratorTurret];
            }
            if(los>900)
            {
                portal = false;
                turret = false;
                human = true;
                target = player;
            }


        }*/
    }

    /// <summary>
    /// Funkcja sprawdza, czy w pobliżu 20 znajduje się wieżyczka
    /// </summary>
    /// <returns>True jeśli wieżyczka znajduje się w 20</returns>
    bool checkTurret()
    {
         
		GameObject g = GameObject.FindGameObjectWithTag ("Range");
        if (/*IsTurrets*/g!=null)
        {
            if (checkDistance(this.transform.position, g.transform.position) < 40)
            {
                return true;
            }
        }
        
        return false;
    
    }

    bool checkPlayer()
    {
        if (checkDistance(this.transform.position, player.transform.position) < 30)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Funkcja losuje nam liczbę z przedziału 0-1000f
    /// </summary>
    /// <returns></returns>
    int losuj()
    {
        return (int)Random.Range(0.0f, 100.0f);
    }

    /// <summary>
    /// Metoda wymuszająca na NavMeshu ruch w dane miejsce, idzie do gracza
    /// </summary>
    void MovePlayer()
    {
        float distance = checkDistance(this.transform.position, target.transform.position);

        //TODO: ODLEGŁOŚCI NALEŻY DOSTOSOWYWAĆ DO WYMIARÓW - W PIĄTEK DOSTOSOWAĆ
        if (distance >= 14.0f)
        {
            //Debug.Log("Idę");
            nav.enabled = true;
            nav.SetDestination(target.transform.position);
            Walk();
        }
        if (distance < 9.0f && checkPlayerMovement() == true)
        {
            //Debug.Log("Stoję i walę");
            nav.enabled = false;
            AttackIdle();
        }
        if (distance < 14.0f && distance >= 9.0f)
        {
            //Debug.Log("Idę i biję");
            nav.enabled = true;
            nav.SetDestination(target.transform.position);
            Attack();
        }

    }

    /// <summary>
    /// Metoda sprawdza, czy gracz się porusza
    /// </summary>
    /// <returns>Zwraca true kiedy gracz się NIE PORUSZA</returns>
    bool checkPlayerMovement()
    {
        float speed;
        speed = player.rigidbody.velocity.magnitude; //Pobranie długości wektora prędkości gracza
        if (speed < 0.5f)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Metoda sprawia, że patyczak idzie w kierunku wieżyczki/portalu
    /// </summary>
    void MoveTurret()
    {
        float distance = checkDistance(this.transform.position, target.transform.position);
        //Logi dotyczące wieżyczek i ich miejsca na świecie
        /*Debug.Log("Target " + turrets[iteratorTurret].transform.position.x + " " + turrets[iteratorTurret].transform.position.y + " " + turrets[iteratorTurret].transform.position.z);
        Debug.Log("Distance " + distance);*/


        //TODO: ODLEGŁOŚCI NALEŻY DOSTOSOWYWAĆ DO WYMIARÓW - W PIĄTEK DOSTOSOWAĆ
        if (distance >= 16.0f)
        {
            //Debug.Log("Idę");
            nav.enabled = true;
            nav.SetDestination(target.transform.position);
            Walk();
        }
        if (distance < 16.0f && distance >= 12.0f)
        {
            //Debug.Log("Idę i biję");
            nav.enabled = true;
            nav.SetDestination(target.transform.position);
            Attack();
        }
        if (distance < 12.0f)
        {
            //Debug.Log("Stoję i walę");
            nav.enabled = false;
            AttackIdle();
        }

    }

    /// <summary>
    /// Checks the distance.
    /// </summary>
    /// <returns>The distance.</returns>
    /// <param name="a">The alpha component.</param>
    /// <param name="b">The blue component.</param>
    private static float checkDistance(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }




    /// <summary>
    /// Animating this instance.
    /// </summary>
    private void Animating()
    {
        anim.SetBool("IsWalking", walk);
        anim.SetBool("IsAttackWalking", attack);
        anim.SetBool("IsAttackIdle", attackIdle);
    }

    /// <summary>
    /// Animuje chodzenia
    /// </summary>
    private void Walk()
    {
        walk = true;
        attack = false;
        attackIdle = false;
    }

    /// <summary>
    /// Ustawia flagi na attack z marszu
    /// </summary>
    private void Attack()
    {
        walk = false;
        attack = true;
        attackIdle = false;
    }

    /// <summary>
    /// Ustawia flagi na attack z miejsca
    /// </summary>
    private void AttackIdle()
    {
        walk = false;
        attack = false;
        attackIdle = true;
    }

    /// <summary>
    /// Służy do spowolnienia patyczaka
    /// </summary>
    /// <param name="slow">Wartość o jaką powinien zwolnić</param>
    public void slowEnemy(float slow)
    {
        float tmpSlow = this.slowValue;
        if (this.slowCount >= 10 & isSlowed)
        { //stun gdy 10x z zrzędu oberwie z freezingTurreta w stanie zamrożenia (czyli w trakcie tych 5sec przedłużanych o kolejne trafienia - statystycznie i w praktyce trudne do osiągnięcia :D)
            this.Moving = false;
            this.stunTime(3);
            this.slowCount = 0;
            //this.counter+=1; //zliczanie ilosci stunów
        }
        else
        {
            this.slowValue = slow;
        }
        nav.acceleration = this.acc * this.slowValue;
        this.isSlowed = true;
        this.slowCount += 1;
        this.slowTime(5, tmpSlow);
        //Debug.Log ("Counter: " + this.slowCount); //info o ilosci udanych stunów
        //Debug.Log ("Acceleration: " + this.nav.acceleration + ",");
    }

    IEnumerator slowTime(float duration, float tmpSlow)
    {

        yield return new WaitForSeconds(duration);   //Wait
        this.slowValue = tmpSlow;
        this.isSlowed = false;
        this.slowCount = 0;
    }

    IEnumerator stunTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        this.Moving = true;
        this.isSlowed = false;
    }
}
