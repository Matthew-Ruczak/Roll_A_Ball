using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_Handler : MonoBehaviour {

	public void restartGame()
    {
        SceneManager.LoadScene(sceneName: "Level_1");
    }
}
