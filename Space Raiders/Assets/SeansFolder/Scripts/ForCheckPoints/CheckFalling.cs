using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class CheckFalling : MonoBehaviour
{
	
	public float resetBelowThisY = -100f;
	public PlayerHealth PH;
	public GameManager GM;

    void Start()
    {
		GM.SpawnPlayer();
    }



    void FixedUpdate()
	{
		if (transform.position.y < resetBelowThisY)
		{
			PH.RespawnPlayer();
			GameAnalytics.NewDesignEvent("Death:Falling");
		}
	}

}
