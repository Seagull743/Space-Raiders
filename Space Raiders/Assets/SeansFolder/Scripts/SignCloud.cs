using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class SignCloud : InteractiveObject
{
    [SerializeField]
    private GameObject FreezeWord;

    private bool tripped = false;
    
    public override void PlayerInteraction()
    {
        StartCoroutine(FreezeText());
        if(tripped == false)
        {
            tripped = true;
            GameAnalytics.NewDesignEvent("LookedAtSign");
        }
    }

    IEnumerator FreezeText()
    {
        FreezeWord.SetActive(true);
        yield return new WaitForSeconds(3);
        FreezeWord.SetActive(false);
    }

}
