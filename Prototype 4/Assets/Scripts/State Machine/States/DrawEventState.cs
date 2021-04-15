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
            _stateMachine.AddSatteliteEventsInHistory(_stateMachine.refillingSatellites);
            _stateMachine.newConditionNReshuffle.SetActive(true);
            yield return new WaitForSeconds(0.7f);

            //reshuffle
            _stateMachine.future.Reshuffle(_stateMachine.history);

            yield return new WaitForSeconds(1f);
        } 
        yield return new WaitForSeconds(0.7f);
        _stateMachine.refillingSatellites.SetActive(false);
        _stateMachine.newConditionNReshuffle.SetActive(false);

        //draw event to event stage
        Event drawnEvent = _stateMachine.future.Draw();
        drawnEvent.Transfer(_stateMachine.eventStageObject.transform, true);
        drawnEvent.gameObject.GetComponent<AudioController>().PlayDraw();  
        

        _stateMachine.SetState(new PlayState(_stateMachine));
        
    }
}
