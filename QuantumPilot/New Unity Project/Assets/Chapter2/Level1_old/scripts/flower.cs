using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class flower : MonoBehaviour
{

    public Stack FlowerTimeBack;
    public GameObject currentPlayer;
    public player2_1 player;
    private StackData PopData;
    Rigidbody2D m_Rigidbody2D;

    public bool collideTurn1;
    public bool collideTurn2;
    public bool collideTurn3;

    public FlowerState_1 flowerTrans;
    // Start is called before the first frame update
    void Start()
    {
        flowerTrans = new FlowerState_1();
        flowerTrans.CreateTrans();
       
        currentPlayer = GameObject.Find("player");
        FlowerTimeBack = new Stack();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        player = (player2_1)currentPlayer.GetComponent<player2_1>();

        collideTurn1 = false;
        collideTurn2 = false;
        collideTurn3 = false;

        InitTrans();
    }

    public void InitTrans()
    {
        flowerTrans.Birth.CurrentOperate =BirthMove;
        flowerTrans.OnGround.CurrentOperate = OnGroundMove;
        flowerTrans.FallGround.CurrentOperate = FallMove;
        flowerTrans.Die.CurrentOperate = Disappear;



    }

    public void UpdateTransition()
    {
        flowerTrans.CollideGround.ifTrans = collideTurn1;
        flowerTrans.LeaveGround.ifTrans = collideTurn2;
        flowerTrans.dying.ifTrans = collideTurn3;




    }

    public void BirthMove()
    {
        transform.Translate(new Vector3(5f, -1f, 0) * Time.deltaTime, Space.World);


    }

    public void FallMove()
    {
        transform.Translate(new Vector3(3f,-2f, 0) * Time.deltaTime, Space.World);

    }

    public void OnGroundMove()
    {
        transform.Translate(new Vector3(3f,0, 0) * Time.deltaTime, Space.World);

    }


    public void Disappear()
    {
        Destroy(this.gameObject);
        this.FlowerTimeBack.Clear();
    }

    public void SaveData()
    {
        StackData data = new StackData();
        data.position = transform.position;

        FlowerTimeBack.Push(data);
    }

    public StackData LoadData()
    {
        for (int i = 1; i < Mathf.Pow(2, player.TimeBackSpeed - 1); i++)
        {
            if (FlowerTimeBack.Count > 1)
                FlowerTimeBack.Pop();
            else
                
            return (StackData)FlowerTimeBack.Peek();


        }
        if (FlowerTimeBack.Count > 1)
            return (StackData)FlowerTimeBack.Pop();
        else
            return (StackData)FlowerTimeBack.Peek();
        
    }

    public void ShowData(StackData CurrentData)                         //Realize Time Rewind
    {
        if (m_Rigidbody2D != null)
        {
        m_Rigidbody2D.simulated = false;
        }
       
        transform.position = CurrentData.position;

    }

    public void Restore()
    {

        if (m_Rigidbody2D != null)
        {
         m_Rigidbody2D.simulated = true;

        }
           


    }
    // Update is called once per frame
    void Update()
    {
        player = (player2_1)currentPlayer.GetComponent<player2_1>();
        if (!player.Rewind)
        {
            normalmove();
        }

        if (player.RewindEnd)
        {
            Restore();
        }
    }

    public void normalmove()
    {
        UpdateTransition();
        flowerTrans.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ground1")
        {
            Debug.Log("ground1");
            collideTurn1 = true;

        }

        if (collision.gameObject.name == "building1")
        {
            Debug.Log("building1");
            collideTurn2 = true;

        }
        if (collision.gameObject.name == "ground222")
        {
            Debug.Log("ground2");
            collideTurn3 = true;

        }



    }

    private void FixedUpdate()
    {
        
        if (player.Rewind)
        {
            if (this.FlowerTimeBack.Count!=0) { 
                PopData = LoadData();
            if (PopData != null)
            {
                ShowData(PopData);
            }
            else
            {
                Destroy(this.gameObject);
                
            }

            if (this.FlowerTimeBack.Count == 1)
            {
                Destroy(this.gameObject);
            } }
           


        }
        else
        {
            SaveData();

        }
    }
}
