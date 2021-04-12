using System.Collections;
using UnityEngine;

internal class DrawEventState : State
{
    public DrawEventState(StateMachine stateMachine) : base(stateMachine) {}

    public override IEnumerator Start()
    {
        //if reshuffle needed
        if (_stateMachine.future.IsEmpty())
        {
            _stateMachine.AddSatteliteEventsInHistory();
            //reshuffle
            _stateMachine.future.Reshuffle(_stateMachine.history);
        }

        //draw event to event stage
        Event drawnEvent = _stateMachine.future.Draw();
        drawnEvent.Transfer(_stateMachine.eventStageObject.transform, true);
        drawnEvent.gameObject.GetComponent<AudioController>().PlayDraw();

        _stateMachine.SetState(new PlayState(_stateMachine));
        yield break;
    }
}
