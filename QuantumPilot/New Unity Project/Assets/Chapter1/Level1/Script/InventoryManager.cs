using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{

   static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;

    private void Start()
    {
        Debug.Log("start");
        //myBag.RefreshList();
        //RefreshItem();
    }
    private void OnEnable()
    {
        //RefreshItem();
    }
    
      void Awake()
      {
          if (instance != null)
          {
              Destroy(this);
          }
          instance = this;
      }

      

    /*
    public static void RefreshItem()
    {
        Debug.Log(instance.slotGrid.transform.childCount);
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < instance.myBag.itemList.Count; i++)
        {

            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
    public static void CreateNewItem(Item item)
    {

        Slot newSlot = Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
        newSlot.gameObject.transform.SetParent(instance.slotGrid.transform);
        newSlot.slotItem = item;
        newSlot.slotImage.sprite =item.image;


        
    }
    
    public static void DeleteItem(Item dItem)
    {

        instance.myBag.DeleteItem(dItem);
    }
    */

    public static void RefreshItem()
    {
        Debug.Log(instance.slotGrid.transform.childCount);
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {

            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {

            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
    public static void CreateNewItem(Item item)
    {

        Slot newSlot = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newSlot.gameObject.transform.SetParent(instance.slotGrid.transform);
        newSlot.slotItem = item;
        newSlot.slotImage.sprite = item.image;



    }

    public static void DeleteItem(Item dItem)
    {

        instance.myBag.DeleteItem(dItem);
    }
}
