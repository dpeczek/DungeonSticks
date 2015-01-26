using UnityEngine;
using System.Collections;

public class PrivateSwordCollides : MonoBehaviour
{
    #region POLA
    public int damage = 10;
    public int percentageDamage = 0;
    private PrivateSwordHealth general;

    //Pola określająca obrażenia od różnych elementów
    public int MagicDamage = 5;
    public int ArrowDamage = 20;
    public int FireballDamage = 30;
    public int BulletDamage = 5;
    public int OtherBulletDamage = 5;
    public int FastBulletDamage = 5;
    public int SniperBulletDamage = 20;

    private int turretDamage;
    private PrivateSwordMover slowDown;
    private float turretSlow;
    #endregion

    /*void Start()
    {
        general = GetComponent<PrivateSwordHealth>();
        slowDown = GetComponent<PrivateSwordMover>();
    }*/

    void Awake()
    {
        Debug.Log("Skrypt kolizyjny is working");
        general = GetComponentInParent<PrivateSwordHealth>();
        slowDown = GetComponentInParent<PrivateSwordMover>();
    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kolizja? "+other.tag+"   "+other.name);
        //GameObject other = collision.gameObject;
        if (other.tag == "Magic" || other.tag == "Arrow")
        {
            
            /*Skoro strzał nastąpił od Playera to ustaw w skrypcie poruszającym patyczakiem zmienną odpowiadającą za to czy został zaatakowany na true*/
            slowDown.IsAttacked = true;
            if (other.tag == "ArrowDamage")
            {
                Debug.Log("Szeregowy obrywa: Arrowem");
                general.TakeDamage(damage, percentageDamage);
            }
            else
            {
                Debug.Log("Szeregowy obrywa: z magii");
                general.TakeDamage(MagicDamage, 0);
            }
            Destroy(other);
        }
        else if (other.tag == "fireball")
        {
            Debug.Log("Szeregowy obrywa: fireballem");
            general.TakeDamage(FireballDamage, percentageDamage);
            Destroy(other);
        }
        else if (other.tag == "Bullet")
        {
            Debug.Log("Szeregowy obrywa: bulletem");
            general.TakeDamage(BulletDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "otherBullet")
        {
            Debug.Log("Szeregowy obrywa: other bulletem");
            general.TakeDamage(OtherBulletDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "fastBullet")
        {
            Debug.Log("Szeregowy obrywa: fast bulletem");
            general.TakeDamage(FastBulletDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "sniperBullet")
        {
            Debug.Log("Szeregowy obrywa: sniperbulletem");
            general.TakeDamage(SniperBulletDamage, percentageDamage);
            Destroy(other);
        }
        else if (other.tag == "sbe")
        {
            general.TakeDamage(10, 0);
            Destroy(other);
        }
        else if (other.tag == "fbe")
        {
            turretSlow = general.freezingBulletSlow.slow;
            slowDown.slowEnemy(5);
            Destroy(other);
        }

    }
}
