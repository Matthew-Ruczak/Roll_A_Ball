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

    /*      ***Fields End***     */

    //This is called on the first frame that the current script is active
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Getting the 'Rigidbody' component from the player object
        playerScore = 0;    //Starting players score from zero
        updatePlayerScore();
        winText.text = "";  //Clearing the 'winMessage_Text', as the player has not beaten the level 
    }

    //This is called before rendering a frame (Game Code Here)
    void Update()
    {
    }

    //This is called before performing an physics calculations (Physical Code Here)
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Getting the current horizontal value of the player
        float moveVertical = Input.GetAxis("Vertical"); //Getting the current vertical value of the player

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);     //Turing the modifed X, Y, Z into a Vector

        rb.AddForce(movement * 10);   //Applying the force to the object (Player)
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

        //Checking if the player has collected all of the 'Pick Up' objects in the current level / game
        Scene currScene = SceneManager.GetActiveScene();

        if (currScene.name == "Level_1" && playerScore >= 3)
        {
            winText.text = "On to level 2!";
            SceneManager.LoadScene(sceneName: "Level_2");
        }
        else if (currScene.name == "Level 2" && playerScore >= 5)
        {
            winText.text = "You win!";
            //winText.text = "On to level 3!";
        }

    }
}
