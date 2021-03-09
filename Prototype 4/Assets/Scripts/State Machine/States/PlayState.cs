using System;
using System.Collections;
using UnityEngine;

internal class PlayState : State
{
    public PlayState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    internal void OnResponse(EventResponse eventResponse) => _stateMachine.SetState(new ExecuteState(_stateMachine, eventResponse));

}