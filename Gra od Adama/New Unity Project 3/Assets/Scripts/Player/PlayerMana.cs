using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{

    public int maxMana = 100;
    public int manaPerSecond = 2;
    private int currentMana;

    public Slider manaSlider;

	// Use this for initialization
	void Start ()
	{
	    currentMana = maxMana;
	    InvokeRepeating("AddManaPerSecond", 5, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddManaPerSecond()
    {
        if (currentMana < maxMana)
        {
            currentMana += manaPerSecond;
            manaSlider.value = currentMana;
        }
    }

    public bool SubtractMana(int amount)
    {
        if (currentMana > amount)
        {
            currentMana -= amount;
            manaSlider.value = currentMana;
            return true;
        }
        return false;
    }
}
