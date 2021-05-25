using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //initilize Gmaeanalytics
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(Starting());
        //Game Analytics here:  start Game
        fade.SetActive(true);
        anim.SetBool("out", true);
        
    }

    IEnumerator Starting()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(3);
    }

    public void InstructionsON()
    {
        menuPage.SetActive(false);
        infoPage.SetActive(true);
    }

    public void InstructionsOFF()
    {
        infoPage.SetActive(false);
        menuPage.SetActive(true);
    }

    public void CreditsON()
    {
        creditsPage.SetActive(true);
        menuPage.SetActive(false);

    }
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
