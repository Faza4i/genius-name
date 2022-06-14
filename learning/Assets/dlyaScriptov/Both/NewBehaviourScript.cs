using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenuUI;
    
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void back ()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
