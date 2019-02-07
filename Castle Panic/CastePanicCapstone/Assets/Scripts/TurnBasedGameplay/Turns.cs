﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{ 
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
    private string nextStateName;

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
                break;//Make this where they draw cards up?
            case (TurnStates.PLAYERTURN):
                break;
                //See Make an RPG Episode 42 discussing abiliites (around 10min)
            case (TurnStates.ENEMYTURN):
                break;
            case (TurnStates.SPAWNNEW):
                //See Make an RPG Episode 41 online around 13:00 min
                break;
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("Next phase"))
        {
            currentStates = (TurnStates)(((int)currentStates + 1) % 4);//4 is the number of states.
                                                                       //There is no easy way to just use the "length" or something
        }
    }

}