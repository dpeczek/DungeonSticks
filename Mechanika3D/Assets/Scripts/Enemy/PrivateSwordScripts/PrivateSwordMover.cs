using UnityEngine;
using System.Collections;

public class PrivateSwordMover : MonoBehaviour {

    #region POLA
    public NavMeshAgent nav;               // Reference to the nav mesh agent.
    Animator anim;                      // Reference to the animator component.


    /// <summary>
    /// Cel do którego ma poruszać się nasz patyczak
    /// </summary>
    GameObject target;

    /// <summary>
    /// Wieża/Drzwi, które patyczak musi zniszczyć, żeby się wydostać
    /// </summary>
    GameObject exit;

    //Referencja do playera
    GameObject player;

    //Referencja do wszystkich wieżyczek
    GameObject[] turrets;

    public bool Moving { get; set; }

    private bool walk;
    private bool attack;
    private bool attackIdle;

    //Iteruje się po ogólnej liczbie wieżyczek
    private int iteratorTurret = 0;
    #endregion



    void Awake()
    {

        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player"); //To się na bieżąco aktualizuje
        turrets = GameObject.FindGameObjectsWithTag("Range"); //Range to póki co tag wieżyczki

        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Moving = true;
        nav.updatePosition = true;
        nav.updateRotation = true;
        nav.SetDestination(player.transform.position);

    }



    void Update()
    {
        if (Moving)
        {
            //Invoke("MoveTurret", 0.3f);
            Invoke("Move", 0.3f);
        }
        else
        {
            nav.enabled = false;
        }
    }

    void FixedUpdate()
    {
        Animating();
    }

    /// <summary>
    /// Metoda wymuszająca na NavMeshu ruch w dane miejsce
    /// </summary>
    void Move()
    {
        float distance = checkDistance(this.transform.position, player.transform.position);

        //TODO: ODLEGŁOŚCI NALEŻY DOSTOSOWYWAĆ DO WYMIARÓW - W PIĄTEK DOSTOSOWAĆ
        if (distance >= 14.0f)
        {
            //Debug.Log("Idę");
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
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
            nav.SetDestination(player.transform.position);
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
    /// Metoda sprawia, że patyczak idzie w kierunku wieżyczki
    /// </summary>
    void MoveTurret()
    {
        float distance = checkDistance(this.transform.position, turrets[iteratorTurret].transform.position);
        //Logi dotyczące wieżyczek i ich miejsca na świecie
        /*Debug.Log("Target " + turrets[iteratorTurret].transform.position.x + " " + turrets[iteratorTurret].transform.position.y + " " + turrets[iteratorTurret].transform.position.z);
        Debug.Log("Distance " + distance);*/


        //TODO: ODLEGŁOŚCI NALEŻY DOSTOSOWYWAĆ DO WYMIARÓW - W PIĄTEK DOSTOSOWAĆ
        if (distance >= 14.0f)
        {
            //Debug.Log("Idę");
            nav.enabled = true;
            nav.SetDestination(turrets[iteratorTurret].transform.position);
            Walk();
        }
        if (distance < 14.0f && distance >= 8.0f)
        {
            //Debug.Log("Idę i biję");
            nav.enabled = true;
            nav.SetDestination(turrets[iteratorTurret].transform.position);
            Attack();
        }
        if (distance < 9.0f)
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
}
