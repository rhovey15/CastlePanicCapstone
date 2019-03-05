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
            randomSpawnPoint = rand.Next(0, spawnPoints.Length);
            randomMonster = rand.Next(0, monsters.Length);
            GameObject monsterObject = UnityEngine.Object.Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);
    }
    
}
