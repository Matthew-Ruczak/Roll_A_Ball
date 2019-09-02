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
    private int playerScore;    //This will store the current number of objects collected
    private bool playerControlsEnabled; //This controls whether or not the users actions affect the player object

    /*      ***Fields End***     */

    //This is called on the first frame that the current script is active
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Getting the 'Rigidbody' component from the player object
        playerScore = 0;    //Starting players score from zero
        updatePlayerScore();
        winText.text = "";  //Clearing the 'winMessage_Text', as the player has not beaten the level
        playerControlsEnabled = true;   //Enabling players controls
    }

    //This is called before rendering a frame (Game Code Here)
    void Update()
    {
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
        else if (currScene.name == "Level_4" && playerScore >= 8)   //Level 3
        {
            winText.text = "You win!";
            playerControlsEnabled = false;  //Disabling players controls becuase the game is over
            //SceneManager.LoadScene(sceneName: "Level_5");
            //winText.text = "On to level 5!";
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
