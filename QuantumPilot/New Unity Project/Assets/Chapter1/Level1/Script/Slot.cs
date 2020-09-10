using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{

    public Item slotItem;
    public Image slotImage;
   // GameObject collectItem;
    public DragPrefab dragItem;
    public DragPrefab newDrag;
    public GameObject closebag;
    public static bool isdragging;
    //public Inventory currentInventory;
    //public InventoryManager currentManager;
    Vector2 cursor;
    
    // Start is called before the first frame update
    void Start()
    {
        isdragging = false;
        closebag = GameObject.FindGameObjectWithTag("MainBag");
        
    }

    void Update()
    {
        cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);



    }
   
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        isdragging = true;
        cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        CreateDragPrefab(cursor);
        closebag.GetComponent<Canvas>().enabled = false ;
        Time.timeScale = 1;

    }
   


    public void OnDrag(PointerEventData eventData)
    {

        newDrag.transform.position = new Vector3(cursor.x, cursor.y, 0);
       // closebag.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isdragging = false;
        closebag.SetActive(false);
        closebag.GetComponent<Canvas>().enabled = true;

        if (newDrag.istrigger == true)
        {

            newDrag.TriggerResponse(newDrag.dragName
                );
            InventoryManager.DeleteItem(slotItem);
            // currentInventory.DeleteItem(slotItem);
            InventoryManager.RefreshItem();
        }else
        {
           // Debug.Log("destroy");
            

           Destroy(newDrag.gameObject);

        }
    }


    public void CreateDragPrefab(Vector2 cursor)
    {
      
        newDrag = Instantiate(this.dragItem);
        
        newDrag.dragItem = this.slotItem;
        
        newDrag.transform.position= new Vector3(cursor.x,cursor.y, 0);
        
    }
}
