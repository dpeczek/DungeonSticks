using UnityEngine;
using System.Collections;

public class GeneralCollides : MonoBehaviour {

    #region POLA
    public int damage = 5;
    public int percentageDamage = 0;
    private GeneralHealth general;
    #endregion

    void Awake()
    {
        general = GetComponentInParent<GeneralHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "otherBullet" || other.tag == "Magic" || other.tag == "Arrow")
        {
            Debug.Log("Oberwałem");
            general.TakeDamage(damage, percentageDamage);
        }

        //TODO: zrobić tak, żeby TYLKO Arrow siekał pół życia
    }
}
