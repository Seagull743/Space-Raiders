using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector3 lastCheckPoint;
    [SerializeField] private GameObject interactcross;

    [SerializeField]
    public Text scoretext;
    public static int theScore;

    [SerializeField]
    private GameObject Crytaltext; 


    void Awake()
    {
        interactcross.SetActive(false);
        Crytaltext.SetActive(false);
        theScore = 0;
    
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        scoretext.text = "Collected  " + theScore + " / 3" ;
    }

    public void InteractCrossOn()
    {
        interactcross.SetActive(true);
    }

    public void InteractCrossoff()
    {
        interactcross.SetActive(false);
    }

    public void CrystalText()
    {
        StartCoroutine(Crystaltext());
    }

    IEnumerator Crystaltext()
    {
        Crytaltext.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Crytaltext.SetActive(false);
    }

}
