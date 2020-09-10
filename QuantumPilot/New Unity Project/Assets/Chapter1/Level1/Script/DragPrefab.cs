using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPrefab : MonoBehaviour
{
    public Vector2 cursorPos;
    public Sprite dragImage;
    public Item dragItem;
    public string dragName;
    public StateMachine newState;
    public string shouldcollide;
    public bool istrigger;
    
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {

        door = GameObject.Find("door");
        istrigger = false;
        name= this.dragItem.Itemname;
        dragName = dragItem.Itemname;
        shouldcollide = dragItem.checkcollide;
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.GetComponent<SpriteRenderer>().sprite = dragItem.image;
        //transform.position = new Vector3(cursorPos.x, cursorPos.y, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name== shouldcollide)
        {
            istrigger = true;
            Debug.Log("HasTriggerDoor");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.name== shouldcollide)
        {
            istrigger = false;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void TriggerResponse(string name)
    {
        newState.ShowResponse(name);
        
    }
}
