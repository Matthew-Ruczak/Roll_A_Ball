using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

    /*      ***Fields***       */
    public GameObject player;   //This holds reference to the player object in the game
    private Vector3 offset;     // This is for holding the offset value for the camera
    /*      ***Fields End***     */


    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position; // Taking the position of the camera - the position of the player to get the offset.
                                                                // This is done so that the camera does not spin, when the ball is spinning.
	}
	
	// Update is called once per frame, but will run at the very end of everything else that needs to be updated (ensures the camera is positioned at the players most recent position)
	void LateUpdate () {
        transform.position = player.transform.position + offset;// Taking the position of the camera + the position of the player to get the offset.
                                                                // This is done so that the camera does not spin, when the ball is spinning.
    }
}
