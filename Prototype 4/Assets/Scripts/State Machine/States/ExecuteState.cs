using System.Collections;
using UnityEngine;

internal class ExecuteState : State
{
    private EventResponse eventResponse;
    private Effect effect;

    public ExecuteState(StateMachine stateMachine, EventResponse eResponse) : base(stateMachine)
    {
        eventResponse = eResponse;
        effect = eventResponse.GetComponent<Effect>();
    }
    public override IEnumerator Start()
    {
        Debug.Log("event execute started");
        if (effect.loss) //loss
        {
            _stateMachine.SetState(new LossState(_stateMachine));
            yield break;
        }

        if (effect.win) //win
        {
            _stateMachine.SetState(new WinState(_stateMachine));
            yield break;
        }

        if (effect.insertEvent != null) //insert new event into history
        {
            GameObject eventObject = UnityEngine.Object.Instantiate(effect.insertEvent, _stateMachine.history.transform);
            Event newEvent = eventObject.GetComponent<Event>();
            _stateMachine.history.AddEvent(newEvent);
        }

        Event currentEvent = effect.gameObject.transform.parent.gameObject.GetComponent<Event>();

        //exhaust or discard event
        if (effect.exhaustable)
            UnityEngine.Object.Destroy(eventResponse.gameObject.transform.parent.gameObject);
        else
            currentEvent.Discard(_stateMachine.history);

        //move all from engaged to recovering
        for (int i = _stateMachine.engagedObject.transform.childCount - 1; i >= 0; i--)
        //while (_stateMachine.engagedObject.transform.childCount > 0)
        {
            //_stateMachine.engagedObject.transform.GetChild(i).SetParent(_stateMachine.recoveringObject.transform);
            Unit u = _stateMachine.engagedObject.transform.GetChild(i).GetComponent<Unit>();
            u.Discard(_stateMachine.recovering);
        }

        _stateMachine.SetState(new DrawUnitState(_stateMachine)); //set new state
        yield break;
    }
}