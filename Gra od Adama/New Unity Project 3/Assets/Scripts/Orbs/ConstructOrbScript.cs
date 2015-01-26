using UnityEngine;
using System.Collections;

public class ConstructOrbScript : MonoBehaviour
{

    #region POLA

    bool flying = true;
    bool moving = false;
    GameObject player;

    #endregion

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("UP");
    }
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.y < 1.5f && !moving==true)
        {
            rigidbody.useGravity = false;
            StartCoroutine("MOVE");
            moving = true;
        }
            
	}

    /// <summary>
    /// sprawi, że orb się wzniesie w górę
    /// </summary>
    /// <returns></returns>
    IEnumerator UP()
    {
            rigidbody.AddForce(0, 5.0f, 0);
            yield return new WaitForSeconds(2);        
    }

    IEnumerator MOVE()
    {
        while (true)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (Vector3.Distance(this.transform.position,player.transform.position)<2)
                rigidbody.velocity = Vector3.zero;
            else
                rigidbody.velocity = getXZ() * 50;
                
            yield return new WaitForSeconds(1);   
        }
        
    }

    /// <summary>
    /// Zwraca Vector kierunku dla naszego orba
    /// </summary>
    /// <returns>Znormalizowany vector prędkości</returns>
    Vector3 getXZ()
    {
        
        float x1 = this.transform.position.x;
        float z1 = this.transform.position.z;

        float x2 = player.transform.position.x;
        float z2 = player.transform.position.z;

        return (new Vector3((x2 - x1), 0.0f, (z2 - z1))).normalized;
    }
}
