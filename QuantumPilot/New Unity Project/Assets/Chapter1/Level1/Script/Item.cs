using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewItem",menuName ="Inventory/NewItem")]
public class Item :ScriptableObject
{
    public string Itemname;
    public Sprite image;
    public string checkcollide;
    public Animator anim;
    public Animation anima;
   


}
