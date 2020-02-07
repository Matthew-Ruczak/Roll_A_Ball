using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu_Buttons : MonoBehaviour
{
    public GameObject inGameMenu_Panel;

    private void Start()
    {
        inGameMenu_Panel.SetActive(false);
    }
    public void openMenu()
    {
        //Pausing Game
        Player_Controls.isGamePaused = true;

        //Opening In Game Menu Panel
        inGameMenu_Panel.SetActive(true);
        Debug.Log("Opening Menu");
    }
    public void resumeGame()
    {
        //Closing in game menu panel
        inGameMenu_Panel.SetActive(false);

        //Unpausing game
        Player_Controls.isGamePaused = false;
    }
    public void exitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void exitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
