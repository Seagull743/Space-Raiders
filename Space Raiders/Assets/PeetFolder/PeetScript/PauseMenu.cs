using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPause = false;

    [SerializeField] GameObject pauseMenuUI;

    [SerializeField] GameObject instructionsPage = null;

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
        pauseMenuUI.SetActive(false);
        instructionsPage.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        instructionsPage.SetActive(false);
        Time.timeScale = 0f;
        GameIsPause = true;
        Cursor.lockState = CursorLockMode.None;
    }



}
