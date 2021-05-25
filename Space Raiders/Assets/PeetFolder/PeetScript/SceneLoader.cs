using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SeanScene");
    }
    
    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu-Final");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
