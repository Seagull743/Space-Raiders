using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 LastCheckPoint;
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

    void Awake()
    {
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

    private void BossSpawnerInternal(GameObject boss)
    {
        boss.SetActive(true);
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
  
    public static void RegisterPlayerCharacter(GameObject interactCross, GameObject crystalText, GameObject pickedUpText, Text scoreText) => Instance.RegisterPlayerCharacterInternal(interactCross, crystalText, pickedUpText, scoreText);
    public static void CrystalText() => Instance.CrystalTextInternal();
    public static void EnergyTextCoroutine() => Instance.EnergyTextCoroutineInternal();
    public static void SetLastCheckpoint(Vector3 checkpoint) => Instance.SetLastCheckpointInternal(checkpoint);
    public static Vector3 GetLastCheckpoint() => Instance.GetLastCheckpointInternal();
    public static bool HasLastCheckpoint() => Instance.HasLastCheckPointInternal();
    public static void InteractCrossOn() => Instance.InteractCrossOnInternal();
    public static void InteractCrossOff() => Instance.InteractCrossOffInternal();
    public static void TheScoreAdd() => Instance.TheScoreInternal();
    public static void BossSpawn(GameObject boss) => Instance.BossSpawnerInternal(boss);

}
