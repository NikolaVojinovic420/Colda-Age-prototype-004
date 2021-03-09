using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{
    public StartState(StateMachine sm) : base(sm) { }


   
    public override IEnumerator Start()
    {
        //create cards - deserialize
        //draw N units
        _stateMachine.SetState(new NewEventState(_stateMachine));
        yield break;
    }
    
}
