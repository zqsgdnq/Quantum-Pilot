using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowl : RewindItem
{
    // Start is called before the first frame update
    void Start()
    {
        InitRewind();
    }

    // Update is called once per frame
    void Update()
    {
        RewindUpdate();
    }

    private void FixedUpdate()
    {
        RewindFixUpdate();
    }
}
