using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollcloud : MonoBehaviour
{

    public rollstar star;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateStar", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateStar()
    {

        rollstar instanceStar = Instantiate(star, transform.position, transform.rotation);

    }
}
