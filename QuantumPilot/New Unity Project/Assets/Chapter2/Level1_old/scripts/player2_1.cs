using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2_1 : basicmovement
{
    // Start is called before the first frame update
    public Stack TimeBack;

    public  bool Rewind;
    public bool RewindEnd;
    private StackData PopData;
    Rigidbody2D m_Rigidbody2D;
    public float TimeBackSpeed;
    public GameObject RewindUI;

    public bool dying;

    public GameObject dyingUI;
   
    // Update is called once per frame

    void Start()
    {
        dying = false;
        Rewind = false;
        RewindEnd = true;
        TimeBackSpeed = 3;
        TimeBack = new Stack();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        dyingUI.SetActive(false);
    }

    public void SaveData()
    {
        StackData data = new StackData();
        data.position = transform.position;
       
        TimeBack.Push(data);
    }

    public StackData LoadData()
    {
        for (int i = 1; i < Mathf.Pow(2, TimeBackSpeed - 1); i++)
        {
            if (TimeBack.Count > 1)
                TimeBack.Pop();
            else
                return (StackData)TimeBack.Peek();
        }
        if (TimeBack.Count > 1)
            return (StackData)TimeBack.Pop();
        else
            return (StackData)TimeBack.Peek();
    }

    public void ShowData(StackData CurrentData)                         //Realize Time Rewind
    {
        m_Rigidbody2D.simulated = false;
        transform.position = CurrentData.position;
      
    }

    public void Restore()
    {

        RewindUI.SetActive(false);
        m_Rigidbody2D.simulated = true;
        
        
    }
    void Update()
    {
        
        Rewind = Input.GetKey(KeyCode.LeftShift);
        RewindEnd = Input.GetKeyUp(KeyCode.LeftShift);
        if (Rewind)
        {
            dyingUI.SetActive(false);
            dying = false;
            Time.timeScale = 1;
            
        }
        if ((!Rewind) && dying == false)
        {
            
            RewindUI.SetActive(false);
      basicmove();
        }

        if (RewindEnd)
        {
            Restore();
        }
        

       if(dying==true)
        {

            Time.timeScale = 0;


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.gameObject.tag == "flower")
        {
            Debug.Log("flower");

            dying = true;
            dyingUI.SetActive(true);
        }


 
    }

    private void FixedUpdate()
    {
        if (Rewind)
        {
            RewindUI.SetActive(true);
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
