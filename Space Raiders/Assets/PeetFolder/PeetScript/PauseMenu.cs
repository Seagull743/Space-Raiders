using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // made static so you can't shoot when paused 
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;

    [SerializeField]
    private GameObject instructions;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()  
    {
        //FindObjectOfType<AudioManager>().Play("UI-Click");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        //FindObjectOfType<AudioManager>().Play("UI-Click");
        pauseMenuUI.SetActive(true);
        instructions.SetActive(false);
        Time.timeScale = 0f;
        GameIsPause = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void InstructionsON()
    {
        //FindObjectOfType<AudioManager>().Play("UI-Click");
        instructions.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void InstructionsOFF()
    {
        //FindObjectOfType<AudioManager>().Play("UI-Click");
        instructions.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void MainMenu()
    {
        //FindObjectOfType<AudioManager>().Play("UI-Click");
        SceneManager.LoadScene(0);
    }

}
