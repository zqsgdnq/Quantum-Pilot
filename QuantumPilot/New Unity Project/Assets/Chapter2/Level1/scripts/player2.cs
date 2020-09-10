using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : RewindPlayer
{
    public Animator anim;
    public bool quantum;
    public static bool dying;
    public BagManager thisBag;
    public bool indoorarea;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        quantum = false;
        dying = false;
        InitRewind();
    }

    // Update is called once per frame
    void Update()
    {
        RewindUpdate();
        if ((!playerRewind)&&dying==false)
        {
            OpenDoor();
            basicmove();
            anim.SetBool("isQuantum", quantum);
            if (Input.GetKeyUp(KeyCode.L)) 
            { quantum = true; }
        }
    }

    private void FixedUpdate()
    {
        RewindFixUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "crab")
        {
            dying = true;
        }
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
    public void OpenDoor()
    {
        if ( (indoorarea)  &&  (Input.GetKeyDown(KeyCode.Q)) && (thisBag.GetCurrentCarryName()== "key") )
            {
            Destroy(door.gameObject);   
        }
    }

}
