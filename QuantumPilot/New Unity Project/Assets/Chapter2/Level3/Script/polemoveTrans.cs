using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polemoveTrans : StateTrans
{

    public State Birth;
    public State Trail1;
    public State Wait1;
    public State Wait2;
    public State Trail2;

    public Transition StartMove;
    public Transition OnCorner1;
    public Transition EndWait1;
    public Transition EndWait2;
    public Transition OnCorner2;
    // Start is called before the first frame update
    public polemoveTrans()
    {
        Trail1 = new State();
        Birth = new State();
        Trail2 = new State();
        Wait1 = new State();
        Wait2 = new State();

        BeginState = Birth;
        CurrentState = BeginState;
        StateList = new List<State>();

        StartMove = new Transition();
        OnCorner1 = new Transition();
        OnCorner2 = new Transition();
        EndWait1 = new Transition();
        EndWait2 = new Transition();
    }

    public void CreateTrans()
    {

        Birth.AddTransition(StartMove, Trail1);
        Trail1.AddTransition(OnCorner1, Wait1);
        Wait1.AddTransition(EndWait1, Trail2);
        Trail2.AddTransition(OnCorner2, Wait2);
        Wait2.AddTransition(EndWait2, Trail1);

        AddState(Birth);
        AddState(Trail1);
        AddState(Trail2);
        AddState(Wait1);
        AddState(Wait2);





    }
}
