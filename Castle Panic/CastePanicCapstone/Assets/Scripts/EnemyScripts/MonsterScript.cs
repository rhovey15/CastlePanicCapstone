using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2D Shooting in Unity (Tutorial)
//https://www.youtube.com/watch?v=wkKsl1Mfp5M

public class MonsterScript : MonoBehaviour
{

    public int hitPoints;
    public int spawnZone;
    public string color;
    public string ring;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Setting ring tags
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

        //Checking structure collision
        if (col.gameObject.tag == "Wall")
        {
            StructureScript structureDetails = col.GetComponent<StructureScript>();
            if (structureDetails.spawnZone == spawnZone)
            {
                Destroy(col.gameObject);
                takeDamage();
            }
        }
        if (col.gameObject.tag == "Tower")
        {
            StructureScript structureDetails = col.GetComponent<StructureScript>();
            if (structureDetails.spawnZone == spawnZone)
            {
                Destroy(col.gameObject);
                DIE();
            }
        }

        if (col.gameObject.tag == "Target")
        {
            DIE(); //Maybe have it spawn back at a random spawn point? You'll have to figure out some way to make it clear that's what happening
        }
    }

    public void takeDamage()
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
        //FindObjectOfType<Turns>().totalMonsters -= 1;
    }
}