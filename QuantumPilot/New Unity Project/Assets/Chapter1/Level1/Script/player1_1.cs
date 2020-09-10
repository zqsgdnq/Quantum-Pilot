using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_1 : basicmovement
{
    public BagManager thisBag;
    public bool indoorarea;
    public GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        basicmove();
        if ((indoorarea) && (Input.GetKeyDown(KeyCode.Q)) && (thisBag.GetCurrentCarryName() == "key"))
        {
            Destroy(door.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "doorarea")
        {
            indoorarea = true;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "doorarea")
        {
            indoorarea = false;
        }
    }
}
