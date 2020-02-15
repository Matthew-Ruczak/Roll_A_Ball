using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controls : MonoBehaviour
{

    /*      *** Start of Fields ***     */
    //public Level_Info levelInfo;    //This allows this script to get information about the current level
    public GameObject player_GameObject;    //Holds reference to the Player Game Object
    private Rigidbody player_Rigidbody;     //Holds reference to the Player's Rigidbody Component
    public Text playerTimer_Text; //Holds reference to the player timer game UI
    public Text playerInstruction_Text;  //Holds reference to the player instructions game UI
    public float player_Speed;      //The speed the player moves
    private bool player_ControlsEnabled;    //Holds whether the controls for the player are enabled
    private double timeRemaining;   //Holds how much time the user has to complete the current level
    public static bool isGameOver;
    public static bool isGamePaused;
    private static bool isPlayingOnMobile;
    /*      *** End of Fields ***     */


    // Start is called before the first frame update
    void Start()
    {
        isPlayingOnMobile = Application.isMobilePlatform;   //Checking if the player is playing on mobile
        player_Rigidbody = player_GameObject.GetComponent<Rigidbody>(); //Getting reference to the player's rigidbody component
        player_Speed = 8f;  //Setting the player's default speed
        player_ControlsEnabled = true;  //Enabling Player Controls
        Debug.Log("Time to Complete Level: " + Level_Info.getCurrLevelTimeToComplete());
        timeRemaining = Level_Info.getCurrLevelTimeToComplete();
        isGameOver = false;
        isGamePaused = false;
    }

    // 
    /*
     *  Non-Physics Operations
     *  
     *  - This function is called once per frame
    */
    void Update()
    {
        if (timeRemaining <= 0 && !isGameOver)   //If the game is over OR the timer is less than zero
        {
            //Setting messages to be displayed to the user
            playerInstruction_Text.text = "Game Over";
            playerTimer_Text.text = "Time Remaining: 0";

            //Disabling player controls
            player_ControlsEnabled = false;

            //setting it to be game over
            isGameOver = true;
        }
        else if (!isGameOver && !isGamePaused)
        {
            //Updating the time the player has left to complete the level
            timeRemaining -= Time.deltaTime;
            playerTimer_Text.text = "Time Remaining: " + System.Math.Round(timeRemaining, 1).ToString();
        }
    }

    /*
     *  Physics Operations
     *  
     *  - This function is called before physics calculations are done
    */
    private void FixedUpdate()
    {
        //Checking if player's controls are enabled
        if (player_ControlsEnabled && !isGamePaused)
        {
            float forcesToApply_X = 0.0f;
            float forcesToApply_Z = 0.0f;
            //Mobile Controls
            if (isPlayingOnMobile)
            {
                //Checking if the acceleration is within the "Deadzone" of the controls
                if (Input.acceleration.x > 0.6f)
                {
                    forcesToApply_X = Input.acceleration.x - 0.6f  * player_Speed;
                }else if (Input.acceleration.x < -0.6f)
                {
                    forcesToApply_X = Input.acceleration.x + 0.6f * player_Speed;
                }
                forcesToApply_Z = Input.acceleration.z * player_Speed * -1;
            }
            else //Desktop Controls (Default)
            {
                forcesToApply_X = Input.GetAxis("Horizontal") * player_Speed;
                forcesToApply_Z = Input.GetAxis("Vertical") * player_Speed;
            }

            //Apply Forces to the Player Game Object
            player_Rigidbody.AddForce(forcesToApply_X, 0.0f, forcesToApply_Z);
        }
    }
}
