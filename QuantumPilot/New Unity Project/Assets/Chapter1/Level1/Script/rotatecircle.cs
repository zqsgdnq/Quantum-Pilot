using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecircle : MonoBehaviour
{
    public float rotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate= Time.deltaTime * 100;
        transform.Rotate(Vector3.forward* rotate, Space.Self);
    }
}
