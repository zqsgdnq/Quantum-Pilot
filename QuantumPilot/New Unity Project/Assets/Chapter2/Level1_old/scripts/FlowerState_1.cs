using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerState_1 :StateTrans
{
    public State Birth;
    public State OnGround;
    public State FallGround;
    public State Die;

    public Transition CollideGround;
    public Transition LeaveGround;
    public Transition dying;
    public FlowerState_1()
    { 
        Birth = new State();
        OnGround = new State();
        FallGround = new State();
        Die = new State();
        BeginState = Birth;
        CurrentState = BeginState;
        StateList = new List<State>();
        CollideGround = new Transition();
        LeaveGround = new Transition();
        dying= new Transition();



    }

    public void CreateTrans()
    {

        Birth.AddTransition(CollideGround,OnGround);
        OnGround.AddTransition(LeaveGround, FallGround);
        FallGround.AddTransition(dying, Die);

        AddState(Birth);
        AddState(OnGround);
        AddState(FallGround);
        AddState(Die);




    }

}
