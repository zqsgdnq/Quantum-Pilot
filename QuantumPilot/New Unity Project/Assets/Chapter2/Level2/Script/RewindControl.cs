using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindControl : RewindBasic
{
    
  

    // Update is called once per frame
    void Update()
    {
        Rewind = Input.GetKey(KeyCode.LeftShift);
        RewindEnd= Input.GetKeyUp(KeyCode.LeftShift);

        if (Rewind)
        {
            player2_2.dying = false;
            Time.timeScale = 1;

        }

        if (player2_2.dying)
        {

            Time.timeScale = 0;

        }

        dyingUI.SetActive(player2_2.dying);
        RewindUI.SetActive(Rewind);

    }
}
