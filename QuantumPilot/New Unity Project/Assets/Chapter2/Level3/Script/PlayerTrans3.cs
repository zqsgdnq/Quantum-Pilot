using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrans3 : StateTrans
{

    public State Birth;
    public State ApplyKey1;
    public State GetStage1;
    public State GetStage2;
    public State Shoot;
    public State ApplyKey2;

    public Transition usingkey1;
    public Transition outdoor;
    public Transition GetArrow;
    public Transition usingArrow;
    public Transition usingkey2;
    public PlayerTrans3()
    {
        Birth = new State();
        ApplyKey1 = new State();
        GetStage1 = new State();
        GetStage2 = new State();
        Shoot = new State();
        ApplyKey2 = new State();

        BeginState = Birth;
        CurrentState = BeginState;
        StateList = new List<State>();

        usingkey1 = new Transition();
        outdoor = new Transition();
        GetArrow = new Transition();
        usingArrow = new Transition();
        usingkey2 = new Transition();
    }

    public void CreateTrans()
    {

        Birth.AddTransition(usingkey1, ApplyKey1);
        ApplyKey1.AddTransition(outdoor, GetStage1);
        GetStage1.AddTransition(GetArrow, GetStage2);
        GetStage2.AddTransition(usingArrow, Shoot);
        Shoot.AddTransition(usingkey2, ApplyKey2);

        AddState(Birth);
        AddState(ApplyKey1);
        AddState(GetStage1);
        AddState(GetStage2);
        AddState(Shoot);
        AddState(ApplyKey2);
    }

}
