using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    [SerializeField] Transform[] positions;
    public float Objectspeed;

    private int nextposindex;
    private Transform nextpos;

    
    // Start is called before the first frame update
    void Start()
    {
        nextpos = positions[0];

        {
            Objectspeed = 5;
        }    
    }

    // Update is called once per frame
    void Update()
    {
       MoveGameObject();
    }


    void MoveGameObject()
    {
        if(transform.position == nextpos.position)
        {
            nextposindex++;
            if(nextposindex >= positions.Length)
            {
                nextposindex = 0;
            }
            nextpos = positions[nextposindex];
        }
        else 
        {
           transform.position = Vector3.MoveTowards(transform.position, nextpos.position, Objectspeed * Time.deltaTime);
        }
       
    }

public void Frozen()
{
    Objectspeed = 2;
}

public void UnFrozen()
{
    Objectspeed = 5;
}

}
