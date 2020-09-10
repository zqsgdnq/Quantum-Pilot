using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class BagManager : MonoBehaviour
{
    public GameObject GameBag;//Bag UI
    
    public GameObject BagGrid;
    public BagSlot SlotPrefab;
    public ToolList thisList;
    public GameObject SureBtn;
    public GameObject CancelBtn;
    public GameObject ShowCarry;
    public GameObject ShowTool;
    //public Sprite showimage;

    public static ToolItem currentChoose;
    public  static ToolItem currentCarry;

    public bool quickOpen;
    void Start()
    {
        currentChoose = null;
        currentCarry = null;
        quickOpen = false;
       // ShowTool = GameObject.Find("ShowImage");
        //showimage = ShowTool.GetComponent<Image>().sprite;
        SureBtn.GetComponent<Button>().onClick.AddListener(ClickSure);
        CancelBtn.GetComponent<Button>().onClick.AddListener(ClickCancel);
        ShowCarry.SetActive(false);
        GameBag.SetActive(false);
        thisList.BagList.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        QuickOpen();
       

        if (currentChoose != null)
        {
            ShowTool.SetActive(true);

            ShowTool.GetComponent<Image>().sprite = currentChoose.ToolImage;
        }
       
    }

    public void QuickOpen()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            quickOpen = !quickOpen; 
            if (quickOpen == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            GameBag.SetActive(quickOpen);
           
        }


    }

    public void AddNewTool(ToolItem newtool)
    {
        if (!thisList.BagList.Contains(newtool)) {
            
        thisList.AddToList(newtool);
        ClearBag();
        for(int j=0; j < thisList.BagList.Count; j++)
        {

            CreateNewTool(thisList.BagList[j]);
        }
 }
        


    }

    public void DeleteTool(ToolItem usedtool)
    {
        if (thisList.BagList.Contains(usedtool)) {
        thisList.DeleteItem(usedtool);
        ClearBag();
        for (int j = 0; j < thisList.BagList.Count; j++)
        {

            CreateNewTool(thisList.BagList[j]);
        }

        if (usedtool == currentCarry)
        {
            currentCarry = null;
            currentChoose = null;
            ShowCarry.SetActive(false);
            ShowTool.SetActive(false);
        } 
        
 }
    }

    public string GetCurrentCarryName()
    {
        if (currentCarry != null)
        {
            return currentCarry.ToolName;
        }
        else
        {

            return null;
        }

    }

    public void ClearBag()
    {
        for (int i = 0; i < BagGrid.transform.childCount; i++)
        {

            if (BagGrid.transform.childCount == 0)
                break;
            Destroy(BagGrid.transform.GetChild(i).gameObject);
        }
    }

    public  void CreateNewTool(ToolItem item)
    {

        BagSlot newSlot = Instantiate(SlotPrefab, BagGrid.transform.position, Quaternion.identity);
        newSlot.gameObject.transform.SetParent(BagGrid.transform);
        newSlot.SlotItem = item;
        newSlot.SlotImage.sprite = item.ToolImage;



    }

    public void ClickSure()
    {
        if (currentChoose != null)
        {
            currentCarry = currentChoose;
            ShowCarry.SetActive(true);
            ShowCarry.GetComponent<Image>().sprite = currentCarry.ToolImage;

        }

        GameBag.SetActive(false);
        Time.timeScale = 1;

    }

    public void ClickCancel()
    {
        GameBag.SetActive(false);
        Time.timeScale = 1;
    }
}
