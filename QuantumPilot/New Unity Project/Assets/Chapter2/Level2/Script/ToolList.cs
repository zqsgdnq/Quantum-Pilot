using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



[CreateAssetMenu(fileName = "NewList", menuName = "ToolList/NewList")]
public class ToolList : ScriptableObject
{
    public List<ToolItem> BagList=new List<ToolItem>();

    public void AddToList(ToolItem newtool)
    {

        BagList.Add(newtool);
        
    }

    public void DeleteItem(ToolItem dItem)
    {
       
        for(int i = 0; i < BagList.Count; i++)
        {
            if (dItem.ToolName == BagList[i].ToolName)
            {
                BagList.Remove(BagList[i]);
            }

        }

        /*
        var dIndex = BagList.FirstOrDefault(c => dItem);
        BagList.Remove(dIndex);
        */

    }

}
