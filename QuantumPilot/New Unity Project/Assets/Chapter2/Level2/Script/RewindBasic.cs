using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindBasic : MonoBehaviour
{
    public static bool Rewind;
    public static bool RewindEnd;

    public GameObject dyingUI;
    public GameObject RewindUI;

    public static float TimeBackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rewind = false;
        RewindEnd = false;
        TimeBackSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
