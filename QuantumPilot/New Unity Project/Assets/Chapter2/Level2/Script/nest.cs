using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nest : MonoBehaviour
{
    public Egg newegg;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEgg", 3f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEgg()
    {

            Egg instanceFlower = Instantiate(newegg, transform.position, transform.rotation);
        
    }
}
