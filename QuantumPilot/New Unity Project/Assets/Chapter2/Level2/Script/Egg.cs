using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public StateTrans EggTrans;
    public State Birth;
    public State OnGround;
    public State Fall;
    public State Die;

    public Transition CollideGround;
    public Transition LeaveGround;
    public Transition dying;

    public bool isOnPlane;
    public bool isLeaveGround;
    public bool isOnGround;


    void Start()
    {
        
        EggTrans = new StateTrans(); 
        
        InitEggTrans();
        
       Birth = new State();
        OnGround = new State();
        Fall = new State();
        Die = new State();

        CollideGround = new Transition();
        LeaveGround = new Transition();
        dying = new Transition();
        EggTrans.BeginState = Birth;
        EggTrans.CurrentState = Birth;
        isOnPlane = false;
        isLeaveGround = false;
        isOnGround = false;
CreateTrans();

    }

    public void InitEggTrans()
    {
        

    }
    public void CreateTrans()
    {

        Birth.AddTransition(CollideGround, OnGround);
        Birth.AddTransition(dying, Die);
        OnGround.AddTransition(LeaveGround, Fall);
        OnGround.AddTransition(dying, Die);
        Fall.AddTransition(dying, Die);

        EggTrans.AddState(Birth);
        EggTrans.AddState(OnGround);
        EggTrans.AddState(Fall);
        EggTrans.AddState(Die);


        Birth.CurrentOperate = FreeFall;
        OnGround.CurrentOperate = OnGroundMove;
        Fall.CurrentOperate = FreeFall;
        Die.CurrentOperate = Disappear;



    }


    public void FreeFall()
    {


    }

    public void OnGroundMove()
    {

        transform.Translate(new Vector3(-3f, 0, 0) * Time.deltaTime, Space.World);
    }


    public void Disappear()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateTransitions();
        EggTrans.Update();
    }

    public void UpdateTransitions()
    {
        CollideGround.ifTrans = isOnPlane;
        LeaveGround.ifTrans = isLeaveGround;
        dying.ifTrans = isOnGround;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EggPlane")
        {
            isOnPlane = true;
            Debug.Log("EggPlane");

        }

        if (collision.gameObject.name == "player")
        {
            Destroy(gameObject);

        }

        if (collision.gameObject.name == "BelowGround")
        {

            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EggPlane")
        {
          //  isLeaveGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EggCorner")
        {
            Debug.Log("EggCorner");
            isLeaveGround = true;
        }
    }
}
