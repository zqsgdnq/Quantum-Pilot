using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCollection : MonoBehaviour
{
    public ToolItem thisTool;
    public BagManager currentManager;
    void Start()
    {
        currentManager = GameObject.Find("ToolBag").GetComponent<BagManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            GameObject.Destroy(this.gameObject);
            currentManager.AddNewTool(thisTool);
        }
    }



}
