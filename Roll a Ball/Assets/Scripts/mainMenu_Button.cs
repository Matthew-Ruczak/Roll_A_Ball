using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu_Button : MonoBehaviour {

    //Starts the game
    public void startGame()
    {
        SceneManager.LoadScene("Level_1");   //Loading level 1
    }

    //Quits the game
    public void endGame()
    {
        Application.Quit();
    }
}
