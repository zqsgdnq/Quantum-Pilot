using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagSlot : MonoBehaviour
{

    public ToolItem SlotItem;
    public Image SlotImage;
    public Sprite showimage;
    public GameObject ShowTool;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(ShowChoose);

       

        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void ShowChoose()
    {

        //showimage = SlotImage.sprite;
        BagManager.currentChoose = this.SlotItem;
    }
}
