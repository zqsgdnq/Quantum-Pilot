using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    
    public ArrayList TransList;
    public delegate void StateDelegate();
    public StateDelegate CurrentOperate;
   // public string StateName;

    public State()
    {
        TransList = new ArrayList();

    }




    public void AddTransition(Transition trans,State nextst)
    {
        
        trans.ifTrans = false;
        trans.NextState = nextst;
        TransList.Add(trans);
    }

    public void CurrentDo()
    {

        CurrentOperate();

    }

}
