using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleRotate : MonoBehaviour
{
    public float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        RotateSpeed = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime, Space.Self);
    }
}
