using UnityEngine;
using System.Collections;

public class FirePrivateSwordCollides : MonoBehaviour {


    #region POLA
    public int damage = 30;
    public int percentageDamage = 0;
    private FirePrivateSwordHealth general;

    private int turretDamage;
    private FirePrivateSwordMover slowDown;
    private float turretSlow;
    #endregion

    void Awake()
    {
        general = GetComponentInParent<FirePrivateSwordHealth>();
        slowDown = GetComponentInParent<FirePrivateSwordMover>();
    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("PRIVATE TRAFIONY");
        if (other.tag == "Magic" || other.tag == "Arrow")
        {

            /*Skoro strzał nastąpił od Playera to ustaw w skrypcie poruszającym patyczakiem zmienną odpowiadającą za to czy został zaatakowany na true*/
            slowDown.IsAttacked = true;
            if (other.tag == "Arrow")
            {
                this.general.TakeDamage(damage, this.percentageDamage);
            }
            else
            {
                this.general.TakeDamage(damage, 0);
            }
            Destroy(other);
        }

        else if (other.tag == "fireball")
        {
            this.general.TakeDamage(damage / 2, this.percentageDamage);
            Destroy(other);
        }

        else if (other.tag == "Bullet")
        {
            this.turretDamage = this.general.basicBulletDamage.damage;
            this.general.TakeDamage(turretDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "otherBullet")
        {
            this.turretDamage = this.general.otherBulletDamage.damage;
            general.TakeDamage(turretDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "fastBullet")
        {
            this.turretDamage = this.general.fastBulletDamage.damage;
            general.TakeDamage(turretDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "sniperBullet")
        {
            this.turretDamage = this.general.sniperBulletDamage.damage;
            general.TakeDamage(turretDamage, this.percentageDamage);
            Destroy(other);
        }
        else if (other.tag == "sbe")
        {
            this.turretDamage = this.general.slowBulletDamage.damage;
            general.TakeDamage(turretDamage, 0);
            Destroy(other);
        }
        else if (other.tag == "fbe")
        {
            this.turretSlow = this.general.freezingBulletSlow.slow;
            this.slowDown.slowEnemy(this.turretSlow);
            Destroy(other);
        }

    }
}
