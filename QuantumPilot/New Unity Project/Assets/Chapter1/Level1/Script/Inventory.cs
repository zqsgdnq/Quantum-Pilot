using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBag", menuName = "Inventory/NewBag")]
public class Inventory : ScriptableObject
{
    public GameObject currentbag;
    public List<Item> itemList = new List<Item>();
   
   
    public void RefreshList()
    {
        if (itemList.Count > 0) {
            itemList.Clear();
        }

    }

    public void DeleteItem(Item dItem)
    {

      var dIndex= itemList.FirstOrDefault(c=>dItem);
        itemList.Remove(dIndex);
      

    }
}
