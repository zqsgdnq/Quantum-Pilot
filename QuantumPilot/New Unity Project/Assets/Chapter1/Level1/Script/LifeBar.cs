using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public GameObject life3;
    public GameObject life2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playermove.lifenum == 2)
        {

            life3.SetActive(false);
        }

        if (playermove.lifenum == 1)
        {

            life2.SetActive(false);
        }

    }
}
