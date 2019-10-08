using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Turns turnScript = new Turns();

    public GameObject winGameUI;
    public GameObject loseGameUI;

    public void WinGame()
    {
        winGameUI.SetActive(true);
        turnScript.enabled = false;
        //Debug.Log("You win!");
    }

    public void LoseGame()
    {
        loseGameUI.SetActive(true);
        turnScript.enabled = false;
        //Debug.Log("You lose...");
    }
}
