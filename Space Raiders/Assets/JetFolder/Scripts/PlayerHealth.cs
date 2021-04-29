using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int startingPlayerHealth;

    public int currentPlayerHealth;

    void Start()
    {
        currentPlayerHealth = startingPlayerHealth;
    }

    void Update()
    {
        
    }
}
