using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFalling : MonoBehaviour
{
   
	public float resetBelowThisY = -100f;
	private Vector3 startingPosition;

	void Awake()
	{
		startingPosition = transform.position;
	}

	void Update()
	{
		if (transform.position.y < resetBelowThisY)
		{
			OnBelowLevel();
		}
	}

	private void OnBelowLevel()
	{
		Debug.Log("Player fell below level");

	}
}
