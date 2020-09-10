using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForthMoveTrans :StateTrans
{
    public State Birth;
    public State Trail1;
    public State Trail2;

    public Transition StartMove;
    public Transition OnCorner1;
    public Transition OnCorner2;

    public ForthMoveTrans()
    {
        Trail1 = new State();
        Birth = new State();
       Trail2= new State();
       
        BeginState = Birth;
        CurrentState = BeginState;
        StateList = new List<State>();
        
        StartMove= new Transition();
        OnCorner1 = new Transition();
        OnCorner2 = new Transition();



    }

    public void CreateTrans()
    {

        Birth.AddTransition(StartMove, Trail1);
       Trail1.AddTransition(OnCorner1, Trail2);
        Trail2.AddTransition(OnCorner2, Trail1);

        AddState(Birth);
        AddState(Trail1);
        AddState(Trail2);
        




    }

}
