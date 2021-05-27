using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Analytics : MonoBehaviour
{
    private int fail = 0;
    private int mobdeath = 0;
    private int falldeath = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLose()
    {
        fail++;
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Game", fail);
        GameAnalytics.NewDesignEvent("deathbymob", mobdeath);
        GameAnalytics.NewDesignEvent("deathbyfall", falldeath);
    }

    private void OnWin()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Game", fail);
        GameAnalytics.NewDesignEvent("");
    }



    
    private void Death()
    {
        //When death by falling
        GameAnalytics.NewDesignEvent("Death:Falling");

        //Death by Mob
        GameAnalytics.NewDesignEvent("Death:Mob");
    }


}
