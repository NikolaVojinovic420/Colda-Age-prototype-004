using System.Collections;
using UnityEngine;

internal class ExecuteState : State
{
    EventResponse eventResponse;
    Effect effect;
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
            UnityEngine.Object.Instantiate(effect.insertEvent, _stateMachine.history.transform);
        if (effect.exhaustable) //exhaust or discard event
            UnityEngine.Object.Destroy(eventResponse.gameObject.transform.parent);
        else eventResponse.gameObject.transform.parent.SetParent(_stateMachine.history.transform);
        while (_stateMachine.engagedObject.transform.childCount > 0) //move all from engaged to recovering
                _stateMachine.engagedObject.transform.GetChild(0).SetParent(_stateMachine.recoveringObject.transform);
        _stateMachine.SetState(new DrawUnitState(_stateMachine)); //set new state
        yield break;
    }
}