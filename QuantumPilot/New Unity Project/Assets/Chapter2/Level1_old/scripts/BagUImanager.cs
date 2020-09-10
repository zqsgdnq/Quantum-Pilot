using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagUImanager : MonoBehaviour
{
    // Start is called before the first frame update

    bool BagOpen;
    public GameObject mybag;
    public Inventory playerInventory;
    public GameObject PausePanel;
    void Start()
    {
        BagOpen = false;
        PausePanel.SetActive(false);
        playerInventory.RefreshList();
        mybag.SetActive(BagOpen);
    }

    // Update is called once per frame
    void Update()
    {
        OpenMyBag();
        GetPause();
    }

    public void OpenMyBag()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            BagOpen = !BagOpen;
            mybag.SetActive(BagOpen);

        }
    }

    public void GetPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PausePanel.SetActive(true);

        }

    }
}
