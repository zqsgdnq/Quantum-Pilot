using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public flower newflower;

    public GameObject currentPlayer;
    public player2_1 player;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = GameObject.Find("player");
        player = (player2_1)currentPlayer.GetComponent<player2_1>();
        InvokeRepeating("CreateFlower", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreateFlower()
    {

        if (!player.Rewind) { flower instanceFlower = Instantiate(newflower, transform.position,transform.rotation);
        }
        

    }
}
