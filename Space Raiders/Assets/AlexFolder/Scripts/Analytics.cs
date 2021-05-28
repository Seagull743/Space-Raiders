using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Analytics : MonoBehaviour
{
    private int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

 
    IEnumerator TimeInScene()
    {
        yield return new WaitForSecondsRealtime(1);
        time++;
    }



}
