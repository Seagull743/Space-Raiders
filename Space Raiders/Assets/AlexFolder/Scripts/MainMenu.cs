using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject fade = null;
    [SerializeField]
    private Animator anim = null;

    [SerializeField]
    private GameObject menuPage = null;
    [SerializeField]
    private GameObject infoPage = null;
    [SerializeField]
    private GameObject creditsPage = null;

    [SerializeField]
    private GameObject quitPromt = null;

    // Start is called before the first frame update
    void Start()
    {
        GameAnalytics.Initialize();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        StartCoroutine(Starting());
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Game");
        fade.SetActive(true);
        anim.SetBool("out", true);

    }


    IEnumerator Starting()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    //Instruction Menu turn On
    public void InstructionsON()
    {
        menuPage.SetActive(false);
        infoPage.SetActive(true);
    }

    //Instruction Menu Turn Off
    public void InstructionsOFF()
    {
        infoPage.SetActive(false);
        menuPage.SetActive(true);
    }

    //Credit page turn on
    public void CreditsON()
    {
        creditsPage.SetActive(true);
        menuPage.SetActive(false);

    }

    //Credit page turn off
    public void CreditsOFF()
    {
        creditsPage.SetActive(false);
        menuPage.SetActive(true);

    }

    //Quit Prompt:
    public void QuitGamePromtON()
    {
        quitPromt.SetActive(true);
        menuPage.SetActive(false);
    }
    public void QuitGamePromtOFF()
    {
        quitPromt.SetActive(false);
        menuPage.SetActive(true);
    }

    //Quit Game
    public void ExitGame()
    {
        Application.Quit();
    }
        


}
