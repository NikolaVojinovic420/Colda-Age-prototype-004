﻿using System.Collections;
using UnityEngine;

public class ExecuteState : State
{
    private readonly Response eventResponse;
    private readonly Effect effect;

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
            // FIXME: unique events are copied, and should not be
            if (!_stateMachine.history.Contains(effect.insertEvent.name) && !_stateMachine.future.Contains(effect.insertEvent.name))
            {
                GameObject eventObject = UnityEngine.Object.Instantiate(effect.insertEvent, _stateMachine.history.transform);
                Event newEvent = eventObject.GetComponent<Event>();
                //newEvent.GetComponent<Animate>().Poof();
                _stateMachine.history.AddEvent(newEvent);
            }
            else
            {
                Debug.Log("inserted event in response already exists in history or future");
            }
        }

        Event currentEvent = eventResponse.gameObject.transform.parent.gameObject.GetComponent<Event>();

        //exhaust or discard event
        if (effect.exhaustable)
            UnityEngine.Object.Destroy(currentEvent.gameObject);
        else
        {
            currentEvent.Transfer(_stateMachine.history.transform, false);
            _stateMachine.history.AddEvent(currentEvent);
        }

        //move all units from engaged back to vigilant
        for (int i = 0; i < _stateMachine.engaged.units.Length; i++)
        {
            Unit u = _stateMachine.engaged.units[i];
            if (u == null)
                continue;
            u.Fatique(2);
            _stateMachine.engaged.TransferUnit(_stateMachine.vigilant, u);
        }

        _stateMachine.engagedAspectsDisplay.SetAspect(new AspectMap());

        _stateMachine.vigilant.Reorder();

        _stateMachine.SetState(new DrawUnitState(_stateMachine));
        yield break;
    }
}
