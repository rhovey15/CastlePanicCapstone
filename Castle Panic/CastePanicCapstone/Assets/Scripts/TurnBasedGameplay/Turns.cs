using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make An RPG Episode 8: Turn-Based Combat Part 1 [Unity, C#]: https://youtu.be/Uhnh8zj_VPo

public class Turns : MonoBehaviour
{
    public MonsterSpawnControl monsterSpawnControlScript = new MonsterSpawnControl(); //Spawn the enemies in a turn
    public EnemyTurn enemyTurnScript = new EnemyTurn();
    int spawnI = 0;
    int enemyI = 0;

    public enum TurnStates
    {
        START, //Start State, where they get new cards?
        PLAYERTURN, //Player's turn (Maybe divide this down?)
        ENEMYTURN, //Enemy's turn. Monsters move forward a ring
        SPAWNNEW //New monsters (2) spawn in random spots on the board
                 //Do I want to add two more states for the end game
                 //when a player wins and when monsters win?
    }

    private TurnStates currentStates;
    
    // Start is called before the first frame update
    void Start()
    {
        currentStates = TurnStates.START; //Always sets the current state to START at the beginning
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentStates);
        switch (currentStates)
        {
            case (TurnStates.START):
                spawnI = 0;
                enemyI = 0;

                break;//Make this where they draw cards up?
            case (TurnStates.PLAYERTURN):
                break;
                //See Make an RPG Episode 42 discussing abiliites (around 10min)
            case (TurnStates.ENEMYTURN):
                while (enemyI < 1)
                {
                    enemyTurnScript.MoveMonsters();
                    enemyI++;
                }

                break;
            case (TurnStates.SPAWNNEW):
                while (spawnI < 1)//REMEMBER TO CHANGE THIS BACK TO 2!!!!!!!!
                {
                    monsterSpawnControlScript.SpawnAMonster();
                    spawnI++;
                }
                break;
        }
    }

    void OnGUI() //Make An RPG Episode 43 (20min ish) has some GUI information 
    {
        if (GUILayout.Button("Next phase"))
        {
            currentStates = (TurnStates)(((int)currentStates + 1) % 4);//4 is the number of states.
                                                                       //There is no easy way to just use the "length" or something
        }
    }

}
