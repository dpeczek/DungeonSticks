using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5.0f;
    public Color flashColor=new Color(1.0f, 0.0f, 0.0f, 0.1f);

    CharacterController characterController;

    private bool damaged;

	// Use this for initialization
	void Start ()
	{
	    characterController = GetComponent<CharacterController>();
	    currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (currentHealth == 0)
        {
            Die();
        }

	    if (damaged)
	    {
	        damageImage.color = flashColor;
	    }
	    else
	    {
	        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed*Time.deltaTime);
	    }

	    damaged = false;
	}

    void OnTriggerEnter(Collider other)
    {
        damaged = true;
        if (other.tag == "MieczPrivate")
        {
            currentHealth -= 10;
            healthSlider.value = currentHealth;
        }
        if (other.tag == "MieczGeneral")
        {
            currentHealth -= 10;
            healthSlider.value = currentHealth;
        }
        if (other.tag == "HealthOrb")
        {
            currentHealth += Losuj(10, 40);
            healthSlider.value = currentHealth;
        }
    }

    void Die()
    {
        Debug.Break();
    }

    int Losuj(int min, int max)
    {
       return (int)Random.Range((float)min, (float)max);
    }
}
