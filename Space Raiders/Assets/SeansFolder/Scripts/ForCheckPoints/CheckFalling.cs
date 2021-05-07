using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
