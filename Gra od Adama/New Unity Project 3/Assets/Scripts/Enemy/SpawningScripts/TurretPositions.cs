using System;
using System.Collections.Generic;
using Assets.Scripts.Enemy.SpawningScripts;
using UnityEngine;
using System.Collections;
/// <summary>
/// Skrypt zajmie się pobraniem informacji na temat pozycji wszystkich wieżyczek na planszy
/// </summary>
public class TurretPositions : MonoBehaviour
{

    #region POLA

    public List<TurretType> TurretsList;//Lista GameObjectow posortowana względem odległości od siebie do spawn pointa
    #endregion

    // Use this for initialization
    void Awake()
    {
        //Stworzenie elementu, który będzie przechowywać pozycje wszystkich wieżyczek
        TurretsList=new List<TurretType>();
        //Pobierz informacje na temat wszystkich wieżyczek
        GameObject[] list = GameObject.FindGameObjectsWithTag("Turret");


        //Przerzuć to do backupa
        for (int i=0; i<list.Length; i++)
        {
            TurretsList.Add(new TurretType(i,list[i],checkDistance(this.transform.position,list[i].transform.position)));
        }

        TurretsList.Sort();

        foreach (TurretType tur in TurretsList)
        {
            Debug.Log("Distance WOLOLOLO: "+ tur.Distance);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
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
}
