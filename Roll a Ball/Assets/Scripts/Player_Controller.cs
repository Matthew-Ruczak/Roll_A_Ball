using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour {

    /*      ***Fields***       */

    public float speed;
    private Rigidbody rb;   //This will hold the component, 'Rigidbody', from the player object
    public Text winText;    //This will hold the text that is displayed when the player has collected all of the objects
    public Text playerScoreText;  //This will hold the object that should have it Text Changed (Set in Unity)
    public Text timerText; //This will hold the reference to the timer_Text UI
    private double timeRemaining; //This will hold the time remaining to complete the level
    private int playerScore;    //This will store the current number of objects collected
    private bool playerControlsEnabled; //This controls whether or not the users actions affect the player object
    private bool isGameOver; //This holds whether or not the game is over

    /*      ***Fields End***     */

    //This is called on the first frame that the current script is active
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Getting the 'Rigidbody' component from the player object
        playerScore = 0;    //Starting players score from zero
        updatePlayerScore();
        winText.text = "";  //Clearing the 'winMessage_Text', as the player has not beaten the level
        timeRemaining = 0;
        playerControlsEnabled = true;   //Enabling players controls
        isGameOver = false;

        //Setting the time for the current level
        switch (SceneManager.GetActiveScene().name)    //Getting the current scene
        {
            case "Level_1":
                timeRemaining = 10.0;
                break;
            case "Level_2":
                timeRemaining = 15.0;
                break;
            case "Level_3":
                timeRemaining = 30.0;
                break;
            case "Level_4":
                timeRemaining = 30.0;
                break;
            case "Level_5":
                timeRemaining = 23.0;
                break;
            case "Level_6":
                timeRemaining = 30.0;
                break;
        }
    }

    //This is called before rendering a frame (Game Code Here)
    void Update()
    {
        //Checking if time has ran out
        if (timeRemaining < 0)
        {
            playerControlsEnabled = false;
            isGameOver = true;
            winText.text = "Times up! Game Over!";
        }
        else
        {
            isGameOver = false;
            //Calculating the time the player has to complete the level since they have started playing
            timeRemaining -= Time.deltaTime;
            //Updating the UI
            timerText.text = "Time Remaining: " + System.Math.Round(timeRemaining, 1).ToString();
        }
}

    //This is called before performing an physics calculations (Physical Code Here)
    void FixedUpdate()
    {
        //Checking if the players controls are enabled
        if (playerControlsEnabled)
        {
            float moveHorizontal = Input.GetAxis("Horizontal"); //Getting the current horizontal value of the player
            float moveVertical = Input.GetAxis("Vertical"); //Getting the current vertical value of the player

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);     //Turing the modifed X, Y, Z into a Vector

            rb.AddForce(movement * 10);   //Applying the force to the object (Player)
        }
    }

    //This is called when the player collides with a Trigger Object
    void OnTriggerEnter(Collider other)
    {
        //This is true when the player comes in contact with an object with the Tag 'Pick Up' (This was set in Unity)
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);  //Hidding the object that the player came in contact
            playerScore++; //incrementing the number of 'Pick Up' the player has collected
            updatePlayerScore();
        }  
    }

    //This updates the Score being displayed on the screen
    private void updatePlayerScore()
    {
        playerScoreText.text = "Score: " + playerScore.ToString();  //Changing the Text property of the Textbox displaying the object to show the newest score

        //Checking if the player has completed the level
        hasCompletedLevel();
    }

    //This checks if the player has completed the level (if the player has collected all of the 'Pick Up' objects)
    private void hasCompletedLevel()
    {
        Scene currScene = SceneManager.GetActiveScene();    //Getting the current scene

        if (currScene.name == "Level_1" && playerScore >= 3)    //Level 1
        {
            winText.text = "On to level 2!";        //Telling the user the they are moving on to the next level
            SceneManager.LoadScene(sceneName: "Level_2");   //Switching the scenes to the next level
        }
        else if (currScene.name == "Level_2" && playerScore >= 7)   //Level 2
        {
            winText.text = "On to level 3!";
            SceneManager.LoadScene(sceneName: "Level_3");
        }
        else if (currScene.name == "Level_3" && playerScore >= 10)   //Level 3
        {
            winText.text = "On to level 4!";
            SceneManager.LoadScene(sceneName: "Level_4");
        }
        else if (currScene.name == "Level_4" && playerScore >= 10)   //Level 3
        {
            winText.text = "You win!";
            isGameOver = true;
            SceneManager.LoadScene(sceneName: "Level_5");
            winText.text = "On to level 5!";
        }
        else if (currScene.name == "Level_5" && playerScore >= 11)   //Level 3
        {
            winText.text = "You win!";
            SceneManager.LoadScene(sceneName: "Level_6");
            winText.text = "On to level 6!";
        }
        else if (currScene.name == "Level_6" && playerScore >= 25)   //Level 3
        {
            winText.text = "You win!";
            playerControlsEnabled = false;  //Disabling players controls becuase the game is over
            winText.text = "You Win!";
        }
        /*
         * User this as a template for the next level
         * 
        else if (currScene.name == "Level_3" && playerScore >= 10)   //Level 3
        {
            winText.text = "You win!";
            playerControlsEnabled = false;  //Disabling players controls becuase the game is over
            //winText.text = "On to level 3!";
        }
        */
    }

    //Brings the user back to the main menu
    public void backToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "Main_Menu");
    }
}
