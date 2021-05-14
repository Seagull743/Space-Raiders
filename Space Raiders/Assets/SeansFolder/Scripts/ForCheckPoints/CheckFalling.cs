using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFalling : MonoBehaviour
{
   
	public float resetBelowThisY = -100f;

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
