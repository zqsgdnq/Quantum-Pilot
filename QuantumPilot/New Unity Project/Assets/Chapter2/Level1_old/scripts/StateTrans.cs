using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrans 
{
    public State CurrentState;
    public List<State> StateList;
    public State BeginState;


    public StateTrans()
    {
        CurrentState = BeginState;
        StateList = new List<State>();

    }
    public void AddState(State s)
    {
        StateList.Add(s);


    }

    public void Update()
    {

        for(int i = 0; i < CurrentState.TransList.Count; i++)
        {
            Transition tempTrans = CurrentState.TransList[i] as Transition;
            if (tempTrans.ifTrans == true)
            {
                this.CurrentState = tempTrans.NextState;
                break;
            }


        }

        CurrentState.CurrentDo();
    }
}
