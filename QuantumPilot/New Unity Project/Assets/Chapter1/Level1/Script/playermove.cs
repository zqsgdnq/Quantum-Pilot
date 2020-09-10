
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    bool BagOpen;
    public GameObject mybag;
    public static bool quantumState;
    public GameObject quantumEffect;
    public Inventory playerInventory;
    public static int lifenum;
    public GameObject PausePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        BagOpen = false;
        PausePanel.SetActive(false);
        playerInventory.RefreshList();
        mybag.SetActive(BagOpen);
        quantumState = false;
        quantumEffect.SetActive(quantumState);
        lifenum = 3;

    }

    // Update is called once per frame
    void Update()
    {
        
            float horizontal = Input.GetAxis("Horizontal");
        //Debug.Log(horizontal);
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;

        float vertical = Input.GetAxis("Vertical");
        //Debug.Log(horizontal);
       // Vector2 position = transform.position;
        position.y = position.y + 0.1f * vertical;

        transform.position = position;
        OpenMyBag();
        GetPause();
        SwitchState();
       
       
    }

    void OpenMyBag()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            BagOpen = !BagOpen;
            mybag.SetActive(BagOpen);

        }
    }

    void GetPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PausePanel.SetActive(true);

        }

    }

    public void SwitchState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            quantumState = !quantumState;
            quantumEffect.SetActive(quantumState);
        }


    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name!=null )
        {

            Debug.Log(collision.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "star")
        {

            Debug.Log("Star");
        }
    }

   


}
