using System.Collections;
using UnityEngine;

internal class DrawEventState : State
{
    public DrawEventState(StateMachine stateMachine) : base(stateMachine) {}

    public override IEnumerator Start()
    {
        //if reshuffle needed
        if (_stateMachine.future.IsEmpty())
            //reshuffle
            _stateMachine.future.Reshuffle(_stateMachine.history);

        //draw event to event stage
        _stateMachine.future.Draw(_stateMachine.eventStage);

        _stateMachine.SetState(new PlayState(_stateMachine));
        yield break;
    }
}