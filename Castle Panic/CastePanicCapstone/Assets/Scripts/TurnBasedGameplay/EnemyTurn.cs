using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to make an object move to another object's location in a 2d game?
//https://answers.unity.com/questions/1179270/how-to-make-an-object-move-to-another-objects-loca.html

public class EnemyTurn : MonoBehaviour
{
    GameObject[] monstersOnBoard;
    GameObject target;

    public void MoveMonsters()
    {
        monstersOnBoard = GameObject.FindGameObjectsWithTag("Monster");
        target = GameObject.Find("Target");

        foreach (GameObject monster in monstersOnBoard)
        {
            monster.transform.position = Vector2.MoveTowards(monster.transform.position, target.transform.position, 0.5f);
        }

   
    }
}
