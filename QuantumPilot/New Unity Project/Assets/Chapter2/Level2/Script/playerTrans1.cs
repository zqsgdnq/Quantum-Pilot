using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrans1 :StateTrans
{
    public State Birth;
    public State ApplyTap;
    public State FireStop;
    public State OpenDoor1;

    public Transition usingTap;
    public Transition stopingfire;
    public Transition usingKey;
    public playerTrans1()
  {
    Birth = new State();
    ApplyTap = new State();
    FireStop = new State();
    OpenDoor1 = new State();
   
    BeginState = Birth;
    CurrentState = BeginState;
    StateList = new List<State>();
    
        usingTap= new Transition();
    stopingfire = new Transition();
    usingKey = new Transition();
}

public void CreateTrans()
{

    Birth.AddTransition(usingTap, ApplyTap);
    ApplyTap.AddTransition(stopingfire, FireStop);
    FireStop.AddTransition(usingKey, OpenDoor1);

    AddState(Birth);
    AddState(ApplyTap);
    AddState(FireStop);
    AddState(OpenDoor1);
}

}

