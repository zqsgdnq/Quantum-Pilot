using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindControl2_1 : RewindBasic
{
    // Update is called once per frame
    void Update()
    {
        Rewind = Input.GetKey(KeyCode.LeftShift);
        RewindEnd = Input.GetKeyUp(KeyCode.LeftShift);

        if (Rewind)
        {
            player2.dying = false;
            Time.timeScale = 1;

        }

        if (player2.dying)
        {

            Time.timeScale = 0;

        }

        dyingUI.SetActive(player2.dying);
        RewindUI.SetActive(Rewind);




    }
}
