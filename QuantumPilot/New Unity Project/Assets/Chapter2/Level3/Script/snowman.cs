using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowman : MonoBehaviour
{
    public snowflower newflower;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateFlower", 3f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFlower()
    {
       
       snowflower instanceFlower = Instantiate(newflower, transform.position, transform.rotation);
        


    }
}
