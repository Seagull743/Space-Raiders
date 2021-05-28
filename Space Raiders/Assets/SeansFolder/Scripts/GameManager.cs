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

    
  //  [SerializeField]
   // private ParticleSystem Ring;

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

    private bool CrystalPurpleCollected = false;
    private bool CrystalGreenCollected = false;
    private bool CrystalPinkCollected = false;
    private bool CrystalBlueCollected = false;

    private bool CrystalPurplePlaced = false;
    private bool CrystalGreenPlaced = false;
    private bool CrystalPinkPlaced = false;
    private bool CrystalBluePlaced = false;

    private bool bossSpawned = false;

     [SerializeField]
     private Slider BossHealthBar;
     [SerializeField]
     private GameObject BossHealthBackground;

    void Awake()
    {

        foreach (GameObject Enemy in EnemysIsland4)
        {
            Enemy.SetActive(false);
        }
        

        Accomplished.SetActive(false);
        Boss.SetActive(false);
       // Ring.Stop();
        bossText.SetActive(false);
        ForceField.SetActive(false);
        BossHealthBackground.SetActive(false);
        BossHealthBar.gameObject.SetActive(false);
        TheScore = 0;
        Instance = this;
    }

    void Update()
    {
        ScoreText.text = "Collected  " + TheScore + " / 4" ;

        BossHealthBar.value = BH.currenthealth;

        //GreenCrystalCollected == true
        if (CrystalGreenCollected == true)
        {
            foreach (GameObject Enemy in EnemysIsland4)
            {
                Enemy.SetActive(true);
            }
        }

       // if (Input.GetKeyDown(KeyCode.O))
      //  {
      //      SpawnTheBoss();
      //  }


       // BlueCrystalplaced && GreenPlaced && PurplePlaced && PinkCrystalplaced
        if (CrystalBluePlaced && CrystalGreenPlaced && CrystalPurplePlaced && CrystalPinkPlaced && bossSpawned)
        {
            if (!SpawnedBoss)
            {
                
                anim.SetBool("sink",true);
                crystalBoss.SetActive(false);        
                ForceField.SetActive(true);
                SpawnTheBoss();
            }
       
            if(BH.BossKilled == true && !youwon)
            {
                youwon = true;
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
        bossSpawned = false;
        SpawnedBoss = false;
        ForceField.SetActive(false);
    }

    private void SpawnTheBoss()
    {
       // Ring.Stop();
        BH.GetComponent<BossHealth>().RespawnEnemy();
        ObjectiveBar.SetActive(false);
        BossHealthBackground.SetActive(true);
        BossHealthBar.gameObject.SetActive(true);
        BossHealthBar.maxValue = BH.maxHealth;
        Boss.transform.position = BossSpawnLocation.position;
        Boss.SetActive(true);
        SpawnedBoss = true;
    } 
    public void InteractCrossOnInternal()
    {
        InteractCross.SetActive(true);
    }
    public void InteractCrossOffInternal()
    {
        InteractCross.SetActive(false);
    }

    private void CrystalTextInternal()
    {
        StartCoroutine(CrystalTextCoroutine());
    }

    private void SetBossSpawnedInternal()
    {
        bossSpawned = true;
    }
    private void BossTextStartInternal()
    {
        StartCoroutine(BossText());
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

     IEnumerator BossText()
    {
        bossText.SetActive(true);
        yield return new WaitForSeconds(3);
        bossText.SetActive(false);
    }

    private void YouWon()
    {
        Accomplished.SetActive(false); 
        Debug.Log("You Won");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Game");
        SceneManager.LoadScene("Win");
        Cursor.lockState = CursorLockMode.None;
    }
 

    public void SpawnPlayer()
    {

        if (CrystalPurpleCollected == false && CrystalGreenCollected == false && CrystalPinkCollected == false && CrystalBlueCollected == false)
        {
            body.transform.position = checkpoint1.position;

        }
        else if (CrystalPurpleCollected == true && CrystalGreenCollected == false && CrystalPinkCollected == false && CrystalBlueCollected == false)
        {
            body.transform.position = checkpoint2.position;
            CheckPoint1Complete = true;
        }
        else if (CrystalPurpleCollected == true && CrystalGreenCollected == true && CrystalPinkCollected == false && CrystalBlueCollected == false)
        {
            body.transform.position = checkpoint3.position;
            CheckPoint1Complete = true;
            CheckPoint2Complete = true;
        }
        else if(CrystalPurpleCollected == true && CrystalGreenCollected == true && CrystalPinkCollected == true && CrystalBlueCollected == false)
        {
            CheckPoint1Complete = true;
            CheckPoint2Complete = true;
            CheckPoint3Complete = true;
            body.transform.position = checkpoint4.position;
        }
        else if (CrystalPurpleCollected == true && CrystalGreenCollected == true && CrystalPinkCollected == true && CrystalBlueCollected == true)
        {
            CheckPoint1Complete = true;
            CheckPoint2Complete = true;
            CheckPoint3Complete = true;
            CheckPoint4Complete = true;
            BossHealthBackground.SetActive(false);
            BossHealthBar.gameObject.SetActive(false);

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

    private bool AllCrystalsPlacedInternal()
    {
        return CrystalBluePlaced && CrystalPinkPlaced && CrystalGreenPlaced && CrystalPurplePlaced;
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

    public static void BossTextStart() => Instance.BossTextStartInternal();
    public static void SetBossSpawned() => Instance.SetBossSpawnedInternal();

    public static void CollectPurpleCrystal() => Instance.CrystalPurpleCollected = true;
    public static void CollectBlueCrystal() => Instance.CrystalBlueCollected = true;
    public static void CollectGreenCrystal() => Instance.CrystalGreenCollected = true;
    public static void CollectPinkCrystal() => Instance.CrystalPinkCollected = true;

    public static void PlacePurpleCrystal() => Instance.CrystalPurplePlaced = true;
    public static void PlaceBlueCrystal() => Instance.CrystalBluePlaced = true;
    public static void PlaceGreenCrystal() => Instance.CrystalGreenPlaced = true;
    public static void PlacePinkCrystal() => Instance.CrystalPinkPlaced = true;
    public static bool AllCrystalsPlaced() => Instance.AllCrystalsPlacedInternal();

}
