using System.Collections;
using UnityEngine;

internal class ExecuteState : State
{
    private Response eventResponse;
    private Effect effect;

    public ExecuteState(StateMachine stateMachine, Response eResponse) : base(stateMachine)
    {
        eventResponse = eResponse;
        effect = eventResponse.GetComponent<Effect>();
    }

    public override IEnumerator Start()
    {
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

        // draw units
        for (int i = 0; i < effect.draw; i++)
            _stateMachine.ReshuffleIfNeededAndDrawUnit();

        Event currentEvent = eventResponse.gameObject.transform.parent.gameObject.GetComponent<Event>();

        //exhaust or discard event
        if (effect.exhaustable)
            UnityEngine.Object.Destroy(currentEvent.gameObject);
        else
            currentEvent.Discard(_stateMachine.history);

        //discard all units in engaged
        for (int i = 0; i < _stateMachine.engaged.units.Length; i++)
        {
            Unit u = _stateMachine.engaged.units[i];
            if (u == null)
                continue;
            _stateMachine.engaged.units[i] = null;
            u.Discard(_stateMachine.recovering);
        }

        _stateMachine.vigilant.reorder();

        _stateMachine.SetState(new DrawUnitState(_stateMachine)); //set new state
        yield break;
    }
}
