using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    public int hitPoints = 1;

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
