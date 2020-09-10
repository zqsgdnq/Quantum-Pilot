using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basiccollection : MonoBehaviour
{

    public Item thisItem;
    public Inventory playerInventory;
   // public bool quantumItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") )
        {
           
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {

        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
        }

        InventoryManager.RefreshItem();
    }
}
