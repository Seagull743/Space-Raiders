using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerspawn : MonoBehaviour
{
    public static GameObject instance;

    public void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
