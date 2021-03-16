using System.Collections;
using UnityEngine;

internal class NewEventState : State
{
    public NewEventState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override IEnumerator Start()
    {
        //if reshuffle needed
        if (_stateMachine.future.IsEmpty())
            //reshuffle
            _stateMachine.future.Reshuffle(_stateMachine.history);

        //draw event to event stage
        Event e = _stateMachine.future.Draw();
        e.gameObject.transform.SetParent(_stateMachine.eventStage.transform);

        //FIXME: do in animation
        e.gameObject.transform.position = _stateMachine.eventStage.transform.position;

        _stateMachine.SetState(new PlayState(_stateMachine));
        yield break;
    }
}