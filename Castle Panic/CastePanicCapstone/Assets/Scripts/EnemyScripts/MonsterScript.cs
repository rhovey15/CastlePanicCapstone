using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2D Shooting in Unity (Tutorial)
//https://www.youtube.com/watch?v=wkKsl1Mfp5M

public class MonsterScript : MonoBehaviour
{
    public int hitPoints;
    public string color;
    public string ring;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Forest")
        {
            ring = "Forest";
        }
        if (col.gameObject.tag == "Archer")
        {
            ring = "Archer";
        }
        if(col.gameObject.tag == "Knight")
        {
            ring = "Knight";
        }
        if (col.gameObject.tag == "Swordsman")
        {
            ring = "Swordsman";
        }
        if (col.gameObject.tag == "TowerRing")
        {
            ring = "Tower";
        }

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