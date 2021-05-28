﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class JumpCloud : MonoBehaviour
{
    private bool tripped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (tripped == false)
        {
            tripped = true;
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "CloudJump");
        }
        
    }

}
