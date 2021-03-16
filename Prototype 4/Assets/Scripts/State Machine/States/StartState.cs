using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{
    public StartState(StateMachine sm) : base(sm) { }



    public override IEnumerator Start()
    {
        Debug.Log($"started");
        //create cards - deserialize
        for (int i = 0; i < 5; i++)
            _stateMachine.DrawUnit();

        _stateMachine.SetState(new NewEventState(_stateMachine));
        yield break;
    }

}
