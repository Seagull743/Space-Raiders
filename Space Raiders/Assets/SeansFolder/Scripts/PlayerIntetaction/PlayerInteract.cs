using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour { 



public Transform playerCam;
public static float maxDistance = 5f;
public GameManager GM;
public LayerMask playerLayer;



// Update is called once per frame
void Update()
{


    if (Input.GetKeyDown(KeyCode.E))
    {
        Pressed();
    }

    RaycastHit hit;
    if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, maxDistance, ~playerLayer))
    {
        var Selection = hit.transform;
        var SelectionComponent = Selection.GetComponent<InteractiveObject>();
        if (SelectionComponent != null)
        {
            GM.InteractCrossOn();
        }
        else
        {
                GM.InteractCrossoff();
        }
    }
    else
    {
            GM.InteractCrossoff();
    }


}

public void Pressed()
{
    RaycastHit hit;

    if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, maxDistance, ~playerLayer))
    {

        GameObject hitObject = hit.transform.gameObject;
        Debug.Log(hitObject.name);

        if (hitObject.GetComponent<InteractiveObject>())
        {
            hitObject.GetComponent<InteractiveObject>().PlayerInteraction();
        }
    }
}
}
    
