using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beammove : RewindItem
{
    public float m_RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        m_RotateSpeed = 10;
        InitRewind();

    }

    // Update is called once per frame
    void Update()
    {
        RewindUpdate();

        if (!RewindControl.Rewind)
        {

transform.Rotate(Vector3.forward* m_RotateSpeed * Time.deltaTime,Space.Self);
        }
        
    }







    private void FixedUpdate()
    {
        RewindFixUpdate();
    }
}
