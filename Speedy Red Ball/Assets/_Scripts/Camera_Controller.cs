using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject player_GameObject;       //Holds Reference to the Player Game Object
    public Camera thirdPersonCamera_CameraObject;     //Holds Reference to the 3rd person camera Game Object
    public Camera twoDCamera_CameraObject;        //Holds Reference to the 2D camera Game Object
    public int cameraToUse_Int;     //Holds a int (0 = 3rd Person, 1 = 2D) that determines which camera to use
    private Camera cameraToUse_CameraObject;      //Holds reference to the Camera Game Object that should be updated
    private Vector3 distanceBetweenPlayerAndThirdPersonCamera;
    private Vector3 distanceBetweenPlayerAnd2DCamera;

    // Start is called before the first frame update
    void Start()
    {
        cameraToUse_Int = 0;    //Setting the default Camera

        //Setting up cameraToUse_GameObject Variable
        if (cameraToUse_Int == 0)   //Since 3rd person camera is to be used
        {
            useThirdPersonCamera();
        } 
        else //Since 3rd person camera is not being used, using the 2D camera
        {
            useTwoDCamera();
        }

        //Getting the distance between the player and the camera as a Vector3
        distanceBetweenPlayerAndThirdPersonCamera = getDistanceBetweenPlayerAndCamera(thirdPersonCamera_CameraObject);
        distanceBetweenPlayerAnd2DCamera = getDistanceBetweenPlayerAndCamera(twoDCamera_CameraObject);
    }

    // 
    /*
     *  Non-Physics Operations
     *  
     *  - This function is called once per frame
    */
    void Update()
    {
        //Checking if the user click the change Camera Key (Currently set to C)
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cameraToUse_Int == 0)   //Switching from 3rd person to 2D
            {
                useTwoDCamera();
                cameraToUse_Int = 1;
            }
            else    //Switching from 2D tp 3rd person
            {
                useThirdPersonCamera();
                cameraToUse_Int = 0;
            }
        }
    }

    /*
     *  Runs once per frame, but will run after everything else has run
     *  - This will update the camera's position, once the player position has been updated
     * 
    */
    void LateUpdate()
    {
        //Updating Camera's position
        if (cameraToUse_Int == 0)   //Since 3rd person camera is being used
        {
            cameraToUse_CameraObject.transform.position = player_GameObject.transform.position + distanceBetweenPlayerAndThirdPersonCamera;
        }
        else //Since 2D camera is being used
        {
            cameraToUse_CameraObject.transform.position = player_GameObject.transform.position + distanceBetweenPlayerAnd2DCamera;
        }
        
    }

    private void useThirdPersonCamera()
    {
        thirdPersonCamera_CameraObject.gameObject.SetActive(true);  //Enabling Camera
        twoDCamera_CameraObject.gameObject.SetActive(false);    //Disabling the other camera
        cameraToUse_CameraObject = thirdPersonCamera_CameraObject;  //Setting camera Game Object to be used
    }

    private void useTwoDCamera()
    {
        twoDCamera_CameraObject.gameObject.SetActive(true); //Enabling Camera
        thirdPersonCamera_CameraObject.gameObject.SetActive(false);
        cameraToUse_CameraObject = twoDCamera_CameraObject; //Setting camera Game Object to be used
    }

    private Vector3 getDistanceBetweenPlayerAndCamera(Camera c)
    {
        return c.transform.position - player_GameObject.transform.position;
    }
}
