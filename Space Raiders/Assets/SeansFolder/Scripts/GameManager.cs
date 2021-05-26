using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour
{
    public Vector3 LastCheckPoint;
    [SerializeField] private GameObject InteractCross;
    private bool LastCheckPointIsSet = false;
    [SerializeField]
    private Text ScoreText;
    private int TheScore;

    [SerializeField]
    private GameObject CrytalText;

    [SerializeField]
    private GameObject PickedUpText;
    //checkpoints
    private static GameManager Instance;
    public CharacterController body;

    [SerializeField]
    private Transform checkpoint1;
    [SerializeField]
    private Transform checkpoint2;
    [SerializeField]
    private Transform checkpoint3;
    [SerializeField]
    private Transform checkpoint4;
    [SerializeField]
    private Transform checkpoint5;
    [SerializeField]
    private Transform bossCheckpoint;



    // Spawn Boss
    [SerializeField]
    private GameObject Boss;
    [SerializeField]
    private Transform BossSpawnLocation;
    private bool SpawnedBoss = false;
    private bool youwon = false;
    [SerializeField]
    private GameObject crystalBoss;

    
    [SerializeField]
    private ParticleSystem Ring;

    [SerializeField]
    private Slider BossHealthBar;
    [SerializeField]
    private GameObject HealthBackGround;
    [SerializeField]
    private GameObject ForceField;
    [SerializeField]
    private GameObject ObjectiveBar;

    [SerializeField]
    private GameObject bossText;
    [SerializeField]
    private GameObject Accomplished;

    public BossHealth BH;

    [SerializeField]
    private Animator anim;
    
    // Enemy spawn checks
    [SerializeField]
    private GameObject[] EnemysIsland1;
    [SerializeField]
    private GameObject[] EnemysIsland2;
    [SerializeField]
    private GameObject[] EnemysIsland3;
    [SerializeField]
    private GameObject[] EnemysIsland4;

    private bool CheckPoint1Complete = false;
    private bool CheckPoint2Complete = false;
    private bool CheckPoint3Complete = false;
    private bool CheckPoint4Complete = false;
    




    void Awake()
    {

        foreach (GameObject Enemy in EnemysIsland4)
        {
            Enemy.SetActive(false);
        }
        Accomplished.SetActive(false);
        Boss.SetActive(false);
        Ring.Stop();
        bossText.SetActive(false);
        ForceField.SetActive(false);
        HealthBackGround.SetActive(false);
        BossHealthBar.gameObject.SetActive(false);
        TheScore = 0;
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    void Update()
    {
        ScoreText.text = "Collected  " + TheScore + " / 4" ;

        BossHealthBar.value = BossHealth.currenthealth / BossHealth.maxHealth;

        if(GreenCrystal.GreenCrystalCollected == true)
        {
            foreach (GameObject Enemy in EnemysIsland4)
            {
                Enemy.SetActive(true);
            }
        }


        if (BlueCrystalShrine.BlueCrystalplaced == true && GreenCrystalShrine.GreenPlaced == true && PurpleCrystalShrine.PurplePlaced == true && PinkCrystalShrine.PinkCrystalplaced == true && BossObject.boss == true)
        {
            if (!SpawnedBoss)
            {
                anim.SetBool("sink",true);
                crystalBoss.SetActive(false);
                ForceField.SetActive(true);
                Ring.Play();
                Invoke("SpawnTheBoss", 4);
            }
            

            if(BossHealth.BossKilled == true && !youwon)
            {
                youwon = true;
                BossHealthBar.gameObject.SetActive(false);
                HealthBackGround.SetActive(false);
                //Can have a you won text then load you won screen
                Accomplished.SetActive(true);
                Invoke("YouWon", 6);
            }
        }

    }
    private void RegisterPlayerCharacterInternal(GameObject interactCross, GameObject pickedUpText, GameObject crystalText, Text scoreText)
    {
        InteractCross = interactCross;
        PickedUpText = pickedUpText;
        CrytalText = crystalText;
        ScoreText = scoreText;

        InteractCross.SetActive(false);
        CrytalText.SetActive(false);
        PickedUpText.SetActive(false);
    }
   
    private void RespawnPlayer()
    {
        Boss.SetActive(false);
        crystalBoss.SetActive(true);
        anim.SetBool("sink", false);
        BossHealthBar.gameObject.SetActive(false);
        HealthBackGround.SetActive(false);
        BossObject.boss = false;
        SpawnedBoss = false;
        ForceField.SetActive(false);
    }

    private void SpawnTheBoss()
    {
        Ring.Stop();
        BH.GetComponent<BossHealth>().RespawnEnemy();
        ObjectiveBar.SetActive(false);
        Boss.transform.position = BossSpawnLocation.position;
        Boss.SetActive(true);
        BossHealthBar.gameObject.SetActive(true);
        HealthBackGround.SetActive(true);
        SpawnedBoss = true;
    }
   
    private void InteractCrossOnInternal()
    {
        InteractCross.SetActive(true);
    }
    private void InteractCrossOffInternal()
    {
        InteractCross.SetActive(false);
    }

    private void CrystalTextInternal()
    {
        StartCoroutine(CrystalTextCoroutine());
    }

    
    public void BossTextStart()
    {
        StartCoroutine(BossText());
    }

     IEnumerator BossText()
    {
        bossText.SetActive(true);
        yield return new WaitForSeconds(2);
        bossText.SetActive(false);
    }
    
    IEnumerator CrystalTextCoroutine()
    {
        CrytalText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        CrytalText.SetActive(false);
    }

    public void EnergyTextCoroutineInternal()
    {
        StartCoroutine(EnergyTextToggle());
    }

    IEnumerator EnergyTextToggle()
    {
        PickedUpText.SetActive(true);
        yield return new WaitForSeconds(3f);
        PickedUpText.SetActive(false);
    }

    private void TheScoreInternal()
    {
        TheScore += 1;
    }

    private void SetLastCheckpointInternal(Vector3 checkpoint)
    {
        LastCheckPointIsSet = true;
        LastCheckPoint = checkpoint;
    }
    private Vector3 GetLastCheckpointInternal()
    {
        return LastCheckPoint;
    }

    private bool HasLastCheckPointInternal()
    {
        return LastCheckPointIsSet;
    }


    private void YouWon()
    {
        Debug.Log("You Won");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Game");
        SceneManager.LoadScene("MainMenu-Final");
    }

    public void SpawnPlayer()
    {

        if (PurpleCrystal.PurpleCrystalCollected == false && GreenCrystal.GreenCrystalCollected == false && PinkCrystal.PinkCrystalCollected == false && BlueCrystal.BlueCrystalCollected == false)
        {
            body.transform.position = checkpoint1.position;

        }
        else if (PurpleCrystal.PurpleCrystalCollected == true && GreenCrystal.GreenCrystalCollected == false && PinkCrystal.PinkCrystalCollected == false && BlueCrystal.BlueCrystalCollected == false)
        {
            body.transform.position = checkpoint2.position;
            CheckPoint1Complete = true;
        }
        else if (PurpleCrystal.PurpleCrystalCollected == true && GreenCrystal.GreenCrystalCollected == true && PinkCrystal.PinkCrystalCollected == false && BlueCrystal.BlueCrystalCollected == false)
        {
            body.transform.position = checkpoint3.position;
            CheckPoint1Complete = true;
            CheckPoint2Complete = true;
        }
        else if(PurpleCrystal.PurpleCrystalCollected == true && GreenCrystal.GreenCrystalCollected == true && PinkCrystal.PinkCrystalCollected == true && BlueCrystal.BlueCrystalCollected == false)
        {
            CheckPoint1Complete = true;
            CheckPoint2Complete = true;
            CheckPoint3Complete = true;
            body.transform.position = checkpoint4.position;
        }
        else if (PurpleCrystal.PurpleCrystalCollected == true && GreenCrystal.GreenCrystalCollected == true && PinkCrystal.PinkCrystalCollected == true && BlueCrystal.BlueCrystalCollected == true)
        {
            CheckPoint1Complete = true;
            CheckPoint2Complete = true;
            CheckPoint3Complete = true;
            CheckPoint4Complete = true;
            
            body.transform.position = checkpoint5.position;
            RespawnPlayer();
        }         
         WaveCheck();
    }

    public void WaveCheck()
    {
//checks the stages Player is at
        if(CheckPoint1Complete)
        {
            foreach(GameObject Ai in EnemysIsland1)
            {            
                
                 if (TryGetComponent<Health>(out var health))
                {
                   health.DestroyEnemy();
                }          
            }
        }
        else if (!CheckPoint1Complete)
        {
            foreach(GameObject Ai in EnemysIsland1)
            {
                Ai.SetActive(true);
                Ai.GetComponent<Health>().RespawnEnemy();                          
            }
        }

        if (CheckPoint2Complete)
        {
            foreach (GameObject Ai in EnemysIsland1)
            {

                if (TryGetComponent<Health>(out var health))
                {
                    health.DestroyEnemy();
                }
            }
        }
        else if (!CheckPoint2Complete)
        {
            foreach (GameObject Ai in EnemysIsland1)
            {
                Ai.SetActive(true);
                Ai.GetComponent<Health>().RespawnEnemy();
            }
        }

        if (CheckPoint3Complete)
        {
            foreach (GameObject Ai in EnemysIsland1)
            {

                if (TryGetComponent<Health>(out var health))
                {
                    health.DestroyEnemy();
                }
            }
        }
        else if (!CheckPoint3Complete)
        {
            foreach (GameObject Ai in EnemysIsland1)
            {
                Ai.SetActive(true);
                Ai.GetComponent<Health>().RespawnEnemy();
            }
        }

        if (CheckPoint4Complete)
        {
            foreach (GameObject Ai in EnemysIsland1)
            {

                if (TryGetComponent<Health>(out var health))
                {
                    health.DestroyEnemy();
                }
            }
        }
        else if (!CheckPoint4Complete)
        {
            foreach (GameObject Ai in EnemysIsland1)
            {
                Ai.SetActive(true);
                Ai.GetComponent<Health>().RespawnEnemy();
            }
        }

    }

   


    public static void RegisterPlayerCharacter(GameObject interactCross, GameObject crystalText, GameObject pickedUpText, Text scoreText) => Instance.RegisterPlayerCharacterInternal(interactCross, crystalText, pickedUpText, scoreText);
    public static void CrystalText() => Instance.CrystalTextInternal();
    public static void EnergyTextCoroutine() => Instance.EnergyTextCoroutineInternal();
    public static void SetLastCheckpoint(Vector3 checkpoint) => Instance.SetLastCheckpointInternal(checkpoint);
    public static Vector3 GetLastCheckpoint() => Instance.GetLastCheckpointInternal();
    public static bool HasLastCheckpoint() => Instance.HasLastCheckPointInternal();
    public static void InteractCrossOn() => Instance.InteractCrossOnInternal();
    public static void InteractCrossOff() => Instance.InteractCrossOffInternal();
    public static void TheScoreAdd() => Instance.TheScoreInternal();
  

}
