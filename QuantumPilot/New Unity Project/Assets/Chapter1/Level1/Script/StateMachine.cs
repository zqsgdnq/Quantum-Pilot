using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "response", menuName = "StateMachine/response")]
public class StateMachine: ScriptableObject
{

   
    public Item keyItem;
    public Inventory currentInventory;
    public GameObject door;
    public GameObject key;
    public GameObject door1;
   
    public void ShowResponse(string name)
    {
        
        Debug.Log("give some response");

        if (name == "shovel")
        {
            currentInventory.itemList.Add(keyItem);
            InventoryManager.RefreshItem();
        }

        if (name =="key")
        {
            Debug.Log("door");
            door = GameObject.Find("door");
            key= GameObject.Find("key");

            Destroy(door);
            Destroy(key);

        }

        if (name == "key1")
        {
            door1 = GameObject.Find("door1");
            Destroy(door1);

        }


    }
   
}
