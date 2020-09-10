using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public crab newcrab;
    void Start()
    {
        InvokeRepeating("CreateCrab", 3f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCrab()
    {
        if ((!RewindControl.Rewind) && (player2.dying == false))
        {
            crab instanceCrab = Instantiate(newcrab, transform.position, transform.rotation);
        }


    }
}
