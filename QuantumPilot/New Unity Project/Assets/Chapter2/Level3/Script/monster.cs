using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public alien newAlien;
    void Start()
    {
        InvokeRepeating("CreateAlien", 3f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAlien()
    {
        if ((!RewindControl.Rewind)&&(player2_3.dying==false)&&(player2_3.PlayerStage==0)) 
        {
            alien instanceAlien = Instantiate(newAlien, transform.position, transform.rotation);
        }
        

    }
}
