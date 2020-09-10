using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crab : rewindItem_State
{
    
    public State Birth;
    public State Walk;
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

        InitRewind();
        Birth = new State();
        Walk = new State();
        Fall = new State();
        Die = new State();

        CollideGround = new Transition();
        LeaveGround = new Transition();
        dying = new Transition();

        ItemTrans.BeginState = Birth;
        ItemTrans.CurrentState = Birth;
        isOnPlane = false;
        isLeaveGround = false;
        isOnGround = false;

        CreateTrans();
    }

    public void CreateTrans()
    {

        Birth.AddTransition(CollideGround, Walk);
       // Birth.AddTransition(dying, Die);
        Walk.AddTransition(LeaveGround, Fall);
       // Walk.AddTransition(dying, Die);
        Fall.AddTransition(dying, Die);

        ItemTrans.AddState(Birth);
        ItemTrans.AddState(Walk);
        ItemTrans.AddState(Fall);
        ItemTrans.AddState(Die);


        Birth.CurrentOperate = FreeFall;
        Walk.CurrentOperate = OnGroundMove;
        Fall.CurrentOperate = FreeFall;
        Die.CurrentOperate = Disappear;



    }
    public void FreeFall()
    {
        transform.Translate(new Vector3(0f, -5f, 0) * Time.deltaTime);
    }
    public void OnGroundMove()
    {
        transform.Translate(new Vector3(3f, 0f, 0) * Time.deltaTime);
    }

    void Disappear()
    {

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        RewindUpdate(); 
        if ((!RewindControl.Rewind) && (!player2.dying))
        {

           ItemTrans.Update();
            
            UpdateTransitions();
        }
        if (RewindControl.Rewind)
        {
            
            clearTransition();
            
        }
    }

    public void UpdateTransitions()
    {
        CollideGround.ifTrans = isOnPlane;
        LeaveGround.ifTrans = isLeaveGround;
        dying.ifTrans = isOnGround;


    }
    

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "crabplane")
        {
            isOnPlane = true;
        }

        if (collision.gameObject.name == "crabfall")
        {
            isLeaveGround = true;
        }

        if (collision.gameObject.name == "sandbottom")
        {
            isOnGround = true;
        }

    }

    public void clearTransition()
    {

        isOnPlane = false;
        isLeaveGround = false;
        isOnGround = false;
        CollideGround.ifTrans = isOnPlane;
        LeaveGround.ifTrans = isLeaveGround;
        dying.ifTrans = isOnGround;

    }

    void FixedUpdate()
    {
        RewindFixUpdate_back();
    }
}
