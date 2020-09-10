using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewindItem_State : MonoBehaviour
{
    public Stack ItemTimeBack;
    public StackState PopData;
    Rigidbody2D m_Rigidbody2D;
    public StateTrans ItemTrans;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void InitRewind()
    {
        ItemTrans = new StateTrans();
        ItemTimeBack = new Stack();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }


    public void SaveData()
    {
        StackState data = new StackState();
        data.position = transform.position;
        data.rotation = transform.rotation;
        data.currentS = ItemTrans.CurrentState;

        ItemTimeBack.Push(data);
    }

    public StackState LoadData()
    {
        for (int i = 1; i < Mathf.Pow(2, RewindControl.TimeBackSpeed - 1); i++)
        {
            if (ItemTimeBack.Count > 1)
                ItemTimeBack.Pop();
            else
                return (StackState)ItemTimeBack.Peek();
        }
        if (ItemTimeBack.Count > 1)
            return (StackState)ItemTimeBack.Pop();
        else
            return (StackState)ItemTimeBack.Peek();
    }

    public void ShowData(StackState CurrentData)                         //Realize Time Rewind
    {
        if (m_Rigidbody2D != null)
        {
            m_Rigidbody2D.simulated = false;
        }

        transform.position = CurrentData.position;
        transform.rotation = CurrentData.rotation;
        ItemTrans.CurrentState = CurrentData.currentS;

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
