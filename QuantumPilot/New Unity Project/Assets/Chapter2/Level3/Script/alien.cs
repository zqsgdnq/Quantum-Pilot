using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : RewindItem
{
    // Start is called before the first frame update
    void Start()
    {
        InitRewind();
    }

    // Update is called once per frame
    void Update()
    {
        RewindUpdate();
        if ((!RewindControl.Rewind)&&(!player2_3.dying))
        {

            transform.Translate( new Vector3(5f,0,0) * Time.deltaTime, Space.Self);
        }
    }

    void FixedUpdate()
    {
        RewindFixUpdate_back();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "door1")||(collision.gameObject.name=="player")||((collision.gameObject.tag == "snowflower")))
        {
            Destroy(gameObject);
        }
    }
}
