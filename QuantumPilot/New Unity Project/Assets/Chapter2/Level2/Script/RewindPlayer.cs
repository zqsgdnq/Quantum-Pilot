using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindPlayer : basicmovement
{
    public Stack TimeBack;
    public Stack CurrentStack;
    private StackData PopData;
    Rigidbody2D m_Rigidbody2D;
    public bool isQuantum;
    public bool playerRewind;


    // Start is called before the first frame update
    void Start()
    {
        TimeBack = new Stack();
        CurrentStack = new Stack();
        CurrentStack = TimeBack;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        isQuantum = false;
        playerRewind = (!isQuantum) && (RewindControl.Rewind);

    }

    public void InitRewind()
    {

        TimeBack = new Stack();
        CurrentStack = new Stack();
        CurrentStack = TimeBack;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        isQuantum = false;
        playerRewind = (!isQuantum) && (RewindControl.Rewind);

    }
    public void SaveData()
    {
        StackData data = new StackData();
        data.position = transform.position;

        CurrentStack.Push(data);
    }

    public StackData LoadData()
    {
        for (int i = 1; i < Mathf.Pow(2, RewindControl.TimeBackSpeed - 1); i++)
        {
            if (CurrentStack.Count > 1)
                CurrentStack.Pop();
            else
                return (StackData)CurrentStack.Peek();
        }
        if (CurrentStack.Count > 1)
            return (StackData)CurrentStack.Pop();
        else
            return (StackData)CurrentStack.Peek();
    }
    // Update is called once per frame

    public void ShowData(StackData CurrentData)                         //Realize Time Rewind
    {
        m_Rigidbody2D.simulated = false;
        transform.position = CurrentData.position;

    }

    public void RewindUpdate()
    {
        playerRewind = (!isQuantum) && (RewindControl.Rewind);

        if(RewindControl.RewindEnd&& (!isQuantum))
        {

            Restore();
        }

    }
    public void Restore()
    {

       
        m_Rigidbody2D.simulated = true;


    }
    void Update()
    {
       
    }

    public void RewindFixUpdate()
    {

        if (playerRewind)
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
}
