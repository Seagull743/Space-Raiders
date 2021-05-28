using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Fallisland : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameAnalytics.NewDesignEvent("LandOnSafetlyIsland");
    }

}
