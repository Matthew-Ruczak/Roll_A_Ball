using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Buttons : MonoBehaviour
{
    public void startGame()
    {
        Debug.Log("Starting Game");
        SceneManager.LoadScene("Level_1");   //Loading level 1
    }

    public void exitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
