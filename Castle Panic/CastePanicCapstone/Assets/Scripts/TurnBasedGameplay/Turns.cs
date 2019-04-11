using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make An RPG Episode 8: Turn-Based Combat Part 1 [Unity, C#]: https://youtu.be/Uhnh8zj_VPo

public class Turns : MonoBehaviour
{
    public MonsterSpawnControl monsterSpawnControlScript = new MonsterSpawnControl();
    public EnemyTurn enemyTurnScript = new EnemyTurn();
    public CardSpawnControl cardSpawnControlScript = new CardSpawnControl();
    
    private string[] currentStateStrings = new string[4]{ "Draw Cards", "Player Turn", "Monsters Move", "Spawn New Monsters" };
    private int currentStateStringsCounter = 1;

    public int spawnMax;
    private int spawnControllerCount;
    private int enemyTurnControllerCount;
    
    public enum TurnStates
    {
        START, //Start State, where they get new cards?
        PLAYERTURN, //Player's turn (Maybe divide this down?)
        ENEMYTURN, //Enemy's turn. Monsters move forward a ring
        SPAWNNEW //New monsters (2) spawn in random spots on the board
                 //Do I want to add two more states for the end game
                 //when a player wins and when monsters win?
    }

    private TurnStates currentState;
    
    private void Start()
    {
        currentState = TurnStates.START; //Always sets the current state to START at the beginning
    }

    private void Update()
    {  
        //Debug.Log(currentState);
        switch (currentState)
        {
            case (TurnStates.START):
                spawnControllerCount = 0;
                enemyTurnControllerCount = 0;
                                
                while (cardSpawnControlScript.cardSpawnPointIterator < cardSpawnControlScript.spawnPoints.Length)
                {
                    cardSpawnControlScript.DealACard();
                    cardSpawnControlScript.cardSpawnPointIterator++;
                }

                break;//Make this where they draw cards up?

            case (TurnStates.PLAYERTURN):
                cardSpawnControlScript.cardSpawnPointIterator = 0;

                break;
                //See Make an RPG Episode 42 discussing abiliites (around 10min)

            case (TurnStates.ENEMYTURN):
                while (enemyTurnControllerCount < 1)
                {
                    enemyTurnScript.MoveMonsters();
                    enemyTurnControllerCount++;
                }
                break;

            case (TurnStates.SPAWNNEW):
                while (spawnControllerCount < spawnMax)
                {
                    monsterSpawnControlScript.SpawnAMonster();
                    spawnControllerCount++;
                }
                break;
        }
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Next: " + currentStateStrings[currentStateStringsCounter]))
        {
            currentState = (TurnStates)(((int)currentState + 1) % currentStateStrings.Length);

            if (currentStateStringsCounter < 3)
            {
                currentStateStringsCounter++;
            }    
            else
            {
                currentStateStringsCounter = 0;
            }
                
        }
    }

}
