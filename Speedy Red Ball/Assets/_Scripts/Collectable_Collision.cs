using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable_Collision : MonoBehaviour
{
    //public Level_Info levelInfo;
    public Text playerScore_Text;
    public Text playerInstruction_Text;
    private int playerScore;
    private int maxScore;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the highest score the player can get for this level
        maxScore = Level_Info.getCurrLevelMaxScore();

        //Checking if a message needs to be displayed
        string levelMessage = Level_Info.getCurrLevelMessage();
        if (levelMessage != null)
        {
            playerInstruction_Text.text = levelMessage;
        }
        else
        {
            playerInstruction_Text.text = "";    //Displaying nothing in the message area text
        }

        Debug.Log("Current Scene Name: " + Level_Info.getCurrentSceneName());
        Debug.Log("The max score for this level is " + maxScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     *  Handles when the collision between the player and a trigger
     *
    */ 
    private void OnTriggerEnter(Collider other)
    {
        //Checking if the GameObject the Player Collided with was a collectable
        if (other.gameObject.CompareTag("collectable"))
        {
            other.gameObject.SetActive(false);  //Hidding the object that the player came in contact
            playerScore++;  //Incrementing the players score
            updatePlayerScore();

            //Checking if the player has reached the max score for this level
            if (playerScore >= maxScore)
            {
                if (Level_Info.loadNextLevel() == -1)
                {
                    playerInstruction_Text.text = "You win";
                    Player_Controls.isGameOver = true;  //This allows the player to keep moving around the final level
                }
                
            }
        }
    }

    //Updates the player Score in the Scene
    private void updatePlayerScore()
    {
        playerScore_Text.text = "Score: " + playerScore.ToString();
    }
}
