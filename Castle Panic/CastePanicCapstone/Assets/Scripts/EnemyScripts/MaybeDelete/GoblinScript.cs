using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2D Shooting in Unity (Tutorial)
//https://www.youtube.com/watch?v=wkKsl1Mfp5M

public class GoblinScript : MonoBehaviour
{
    public int hitPoints;
    public string color; 

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Destroy(col.gameObject);
            takeDamage();
        }
    }

    void takeDamage()
    {
        hitPoints -= 1;
        if (hitPoints <= 0)
        {
            DIE();
        }
    }

    void DIE()
    {
        Destroy(gameObject);
    }
}
