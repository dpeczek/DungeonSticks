using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Enemy.SpawningScripts
{
    /// <summary>
    /// Klasa będąca pomocą przy zarządzaniu pozycjami wieżyczek
    /// </summary>
    public class TurretType: IComparable<TurretType>
    {
        public int Index { get; set; }
        public GameObject Turret;
        public float Distance { get; set; }

        /// <summary>
        /// Konstruktor klasy Turret
        /// </summary>
        /// <param name="index">Pozycja wieżyczki</param>
        /// <param name="position">Pozycja wieżyczki</param>
        /// <param name="distance">Dystans między spawn pointem, a wieżyczką</param>
        public TurretType(int index, GameObject turret, float distance)
        {
            Index = index;
            Turret = turret;
            Distance = distance;
        }

        /// <summary>
        /// Metoda porównywuje po dystansie, między wieżyczkami
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TurretType other)
        {
            //0 jak równe
            if (Distance == other.Distance)
                return 0;
            //Jak ten dystans jest mniejszy to -1
            if (Distance < other.Distance)
                return -1;
            //Jak dystans jest w wuj duży to daj 1
            if (Distance > other.Distance)
                return 1;
            return -1;
        }
    }
}
