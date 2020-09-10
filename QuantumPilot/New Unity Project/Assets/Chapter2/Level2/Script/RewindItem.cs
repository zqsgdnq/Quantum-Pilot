using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindItem : MonoBehaviour
{
    public Stack ItemTimeBack;
    private StackRotate PopData;
    Rigidbody2D m_Rigidbody2D;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void InitRewind()
    {
 ItemTimeBack = new Stack();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }


    public void SaveData()
    {
        StackRotate data = new StackRotate();
        data.position = transform.position;
        data.rotation = transform.rotation;

        ItemTimeBack.Push(data);
    }

    public StackRotate LoadData()
    {
        for (int i = 1; i < Mathf.Pow(2, RewindControl.TimeBackSpeed - 1); i++)
        {
            if (ItemTimeBack.Count > 1)
                ItemTimeBack.Pop();
            else
                return (StackRotate)ItemTimeBack.Peek();
        }
        if (ItemTimeBack.Count > 1)
            return (StackRotate)ItemTimeBack.Pop();
        else
            return (StackRotate)ItemTimeBack.Peek();
    }

    public void ShowData(StackRotate CurrentData)                         //Realize Time Rewind
    {
        if (m_Rigidbody2D != null)
        {
           m_Rigidbody2D.simulated = false;
        }
       
        transform.position = CurrentData.position;
        transform.rotation = CurrentData.rotation;

    }

    public void Restore()
    {

        if (m_Rigidbody2D != null)
        {
        m_Rigidbody2D.simulated = true;
        }
       


    }

    void Update()
    {
        





    }


    public void RewindUpdate()
    {

        if (RewindControl.RewindEnd)
        {
            Restore();
        }
    }

    public void RewindFixUpdate()
    {

        if (RewindControl.Rewind)
        {
            //  RewindUI.SetActive(true);
            PopData = LoadData();
            if (PopData != null)
            {
                ShowData(PopData);
            }


        }
        else
        {
            SaveData();

        }
    }


    public void RewindFixUpdate_back()
    {
        if (RewindControl.Rewind)
        {
            if (this.ItemTimeBack.Count != 0)
            {
                PopData = LoadData();
                if (PopData != null)
                {
                    ShowData(PopData);
                }
                else
                {
                    Destroy(this.gameObject);

                }

                if (this.ItemTimeBack.Count == 1)
                {
                    Destroy(this.gameObject);
                }
            }



        }
        else
        {
            SaveData();

        }

    }
}
