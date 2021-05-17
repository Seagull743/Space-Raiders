using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFalling : MonoBehaviour
{
	
	public float resetBelowThisY = -100f;
	public GameManager GM;

    void Start()
    {
		GM.SpawnPlayer();
    }

    void FixedUpdate()
	{
		if (transform.position.y < resetBelowThisY)
		{
			GM.SpawnPlayer();
		}
	}

	
}
