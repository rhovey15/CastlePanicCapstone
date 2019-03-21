using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to Spawn Monsters Randomly from different Spawn Points
//and Make them Follow the Player in Unity: https://www.youtube.com/watch?v=q1gAtOWTs-o

public class MonsterSpawnControl : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] monsters;
    public System.Random rand = new System.Random();
    int randomSpawnPoint, randomMonster;
    int i;

    public void SpawnAMonster()
    {
        int goblin = 0;
        int orc = 1;
        int troll = 2;
        randomSpawnPoint = rand.Next(0, spawnPoints.Length);
        randomMonster = rand.Next(0, monsters.Length);
        GameObject monsterObject = UnityEngine.Object.Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);

        MonsterScript monsterDetails = monsterObject.GetComponent<MonsterScript>();
        //Set hit points based on monster 
        if (randomMonster == goblin)
        {
            monsterDetails.hitPoints = 1;
        }
        else if (randomMonster == orc)
        {
            monsterDetails.hitPoints = 2;
        }
        else if (randomMonster == troll)
        {
            monsterDetails.hitPoints = 3;
        }

        //Set color attribute based on spawn point
        //switch (randomSpawnPoint)
        //{
        //    case 0:
        //    case 1:
        //        monsterDetails.color = "Red";
        //        break;
        //    case 2:
        //    case 3:
        //        monsterDetails.color = "Green";
        //        break;
        //    case 4:
        //    case 5:
        //        monsterDetails.color = "Blue";
        //        break;
        //}
        if (randomSpawnPoint == 0 || randomSpawnPoint == 1)
        {
            monsterDetails.color = "Red";
        }
        else if (randomSpawnPoint == 2 || randomSpawnPoint == 3)
        {
            monsterDetails.color = "Green";
        }
        else if (randomSpawnPoint == 4 || randomSpawnPoint == 5)
        {
            monsterDetails.color = "Blue";
        }

    }

}
