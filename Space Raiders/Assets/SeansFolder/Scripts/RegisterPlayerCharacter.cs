using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject interactCross;
    [SerializeField]
    private GameObject crystalText;
    [SerializeField]
    private GameObject pickedUpText;
    [SerializeField]
    private Text scoreText;



    // Start is called before the first frame update
    void Start()
    {
        GameManager.RegisterPlayerCharacter(interactCross, crystalText, pickedUpText, scoreText);
    }
}
