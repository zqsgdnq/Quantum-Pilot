using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polecollide : MonoBehaviour
{

    public GameObject targetpole;
    public Transform polepos;
    // Start is called before the first frame update
    void Start()
    {
        polepos = targetpole.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(polepos.position.x, polepos.position.y, polepos.position.z);
    }
}
