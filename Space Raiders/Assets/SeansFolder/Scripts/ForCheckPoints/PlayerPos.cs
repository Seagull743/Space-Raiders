using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.HasLastCheckpoint())
        transform.position = GameManager.GetLastCheckpoint();
    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
    }

}
