using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Info : MonoBehaviour
{
    private static int numberOfLevels = 7;
    //Returns the name of the current scene
    public  static string getCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;  //Returning the name of the current scene
    }

    //Returns the max number score for the current level
    public static int getCurrLevelMaxScore()
    {
        //Return the max score depending on the current scene
        switch (getCurrentSceneName())
        {
            //Create a new case when creating a new level
            case "Level_1": return 3;
            case "Level_2": return 4;
            case "Level_3": return 17;
            case "Level_4": return 17;
            case "Level_5": return 33;
            case "Level_6": return 35;
            case "Level_7": return 35;
            default: return -1;
        }
    }
    public static string getCurrLevelMessage()
    {
        //Return the max score depending on the current scene
        switch (getCurrentSceneName())
        {
            //Create a new case when creating a new level
            case "Level_1": return "Controls: \n" +
                    "W = Forward \n" +
                    "S = Backward \n" +
                    "A = Left \n" +
                    "D = Right \n" +
                    "C = Change Camera";
            default: return null;
        }
    }

    public static double getCurrLevelTimeToComplete()
    {
        //Return the max score depending on the current scene
        switch (getCurrentSceneName())
        {
            //Create a new case when creating a new level
            case "Level_1":
                return 25.0;
            case "Level_2":
                return 15.0;
            case "Level_3":
                return 30.0;
            case "Level_4":
                return 60.0;
            case "Level_5":
                return 10000.0;
            case "Level_6":
                return 10000.0;
            case "Level_7":
                return 100000.0;
            default: return 30.0;
        }
    }

    public static int loadNextLevel()
    {
        //Getting the next level's number
        int nextLevelNum = System.Int32.Parse(getCurrentSceneName().Split('_')[1]) + 1;
        //Checking if the next level exist (Checking if their is another level)
        if (!(nextLevelNum > numberOfLevels))
        {
            SceneManager.LoadScene(sceneName: "Level_" + nextLevelNum);
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
