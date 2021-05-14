using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    [SerializeField] Transform[] positions;
    public float Objectspeed;


    [SerializeField]
    private int nextposindex;
    [SerializeField]
    private Transform nextpos;

    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.layer = default;
        nextpos = positions[0];
        

        {
            Objectspeed = 6;
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
    Objectspeed = 0;
    gameObject.GetComponent<BoxCollider>().isTrigger = false;
        this.gameObject.layer = 8;
    }

    public void UnFrozen()
    {
    Objectspeed = 6;
    gameObject.GetComponent<BoxCollider>().isTrigger = true;
    this.gameObject.layer = default;
    }

}
