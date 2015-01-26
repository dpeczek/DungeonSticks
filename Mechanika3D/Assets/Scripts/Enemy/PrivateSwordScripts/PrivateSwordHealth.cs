using UnityEngine;
using System.Collections;

public class PrivateSwordHealth : MonoBehaviour {

    public int Health = 10;
    Animator anim;                      // Reference to the animator component.
    PrivateSwordMover mover;
    // Use this for initialization
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mover = GetComponent<PrivateSwordMover>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            mover.Moving = false;
            anim.SetTrigger("Dead");
            //Zmiana tagu, żeby już wieżyczki w niego nie strzelały
            gameObject.tag = "Neutral";
            Destroy(gameObject, 5);

        }
    }

    /// <summary>
    /// Takes the damage	/// </summary>
    /// <param name="damage">Obrażenia jakie przyjmie (o ile wystąpią)</param>
    /// <param name="perceantage">Procentowe jebnięcie (o ile wystąpi)</param>
    public void TakeDamage(int damage, int perceantage)
    {
        Health -= damage;
        Health -= (Health * perceantage);
    }
}
