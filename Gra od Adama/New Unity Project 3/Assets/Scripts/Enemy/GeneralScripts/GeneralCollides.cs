using UnityEngine;
using System.Collections;

public class GeneralCollides : MonoBehaviour {

    #region POLA
    public int damage = 5;
    public int percentageDamage = 0;
    private GeneralHealth general;

    //Pola określająca obrażenia od różnych elementów
    public int MagicDamage = 5;
    public int ArrowDamage = 20;
    public int FireballDamage = 30;
    public int BulletDamage = 5;
    public int OtherBulletDamage = 5;
    public int FastBulletDamage = 5;
    public int SniperBulletDamage = 20;

	private int turretDamage;
	private GeneralMover slowDown;
	private float turretSlow;
    #endregion

    void Start()
    {
        general = GetComponentInParent<GeneralHealth>();
        slowDown = GetComponentInParent<GeneralMover>();
    }

    /*void Awake()
    {
        general = GetComponentInParent<GeneralHealth>();
		slowDown = GetComponentInParent<GeneralMover> ();
    }*/



    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Magic" || other.tag == "Arrow")
        {

            /*Skoro strzał nastąpił od Playera to ustaw w skrypcie poruszającym patyczakiem zmienną odpowiadającą za to czy został zaatakowany na true*/
            slowDown.IsAttacked = true;
            if (other.tag == "ArrowDamage")
            {
                general.TakeDamage(damage, percentageDamage);
            }
            else
            {
                general.TakeDamage(MagicDamage, 0);
            }
            Destroy(other);
        }
        else if (other.tag == "fireball")
        {
            general.TakeDamage(FireballDamage, percentageDamage);
            Destroy(other);
        }
        else if (other.tag == "Bullet")
        {
            general.TakeDamage(BulletDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "otherBullet")
        {
            general.TakeDamage(OtherBulletDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "fastBullet")
        {
            general.TakeDamage(FastBulletDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "sniperBullet")
        {
            general.TakeDamage(SniperBulletDamage, percentageDamage);
            Destroy(other);
        }
        else if (other.tag == "sbe")
        {
            general.TakeDamage(turretDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "fbe")
        {
            turretSlow = general.freezingBulletSlow.slow;
            slowDown.slowEnemy(turretSlow);
            Destroy(other);
        }

    }
}