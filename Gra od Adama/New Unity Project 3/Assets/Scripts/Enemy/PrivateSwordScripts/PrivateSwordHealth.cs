using UnityEngine;
using System.Collections;

public class PrivateSwordHealth : MonoBehaviour {

    public int Health = 100;
    Animator anim;                      // Reference to the animator component.
    PrivateSwordMover mover;

    public Bullet basicBulletDamage; //References to all the bullets that can hit him
    public Bullet otherBulletDamage;
    public Bullet fastBulletDamage;
    public Bullet sniperBulletDamage;
    public slowBulletExplosionRange slowBulletDamage;
    public freezingBulletExplosionRange freezingBulletSlow;
    public GameObject constructOrb;
    // Use this for initialization
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mover = GetComponent<PrivateSwordMover>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Health <= 0 && mover.Moving == true)
        {
            mover.Moving = false;//Poruszanie ma się wyłączyć
            anim.SetTrigger("Dead");//Odpala animację śmierci
            //Zmiana tagu, żeby już wieżyczki w niego nie strzelały
            /*GameObject go = GameObject.Find("Basic_Torso1");
            go.tag = "Neutral";*/
            foreach (Transform t in this.transform)
            {
                if (t.name == "Point001")
                {
                    foreach(Transform t2 in t.transform)
                    {
                        if(t2.name == "Basic_Pelvis")
                        {
                            foreach(Transform t3 in t2.transform)
                            {
                                if (t3.name == "Basic_Torso1")
                                {
                                    t3.tag = "Neutral";
                                    Instantiate(constructOrb, t3.transform.position, t3.transform.rotation);
                                }
                            }
                        }
                    }
                }
            }
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
        //Debug.Log("d: " +damage + " p: "+ perceantage +" Hp = "+this.Health);
    }
}
