using System;
using System.Collections;
using UnityEngine;

public class PlayState : State
{
    public PlayState(StateMachine stateMachine) : base(stateMachine) {}
    public override IEnumerator Start()
    {
        int index = _stateMachine.vigilant.units.Length;
        for (int i = 0; i < index; i++)
        {
            Unit u = _stateMachine.vigilant.units[i];
            if (u.timeToRecovery == 1 && u.bringsLoot)
            {
                _stateMachine.supplies.ReturnLoot();
                u.bringsLoot = false;
            }
            u.Recover(1);
            _stateMachine.vigilantAspectsDisplay.SetAspect(_stateMachine.vigilant.CalcAspectSum());
        }
        yield break;
    }
    public override IEnumerator ResponseClicked(Response eventResponse)
    {
        _stateMachine.SetState(new ExecuteState(_stateMachine, eventResponse));
        yield break;
    }
    public override IEnumerator UnitClicked(Unit unit)
    {
        Event e = _stateMachine.eventStageObject.GetComponentInChildren<Event>();//if we deffend settlement

        if (_stateMachine.engaged.Contains(unit))
            _stateMachine.engaged.TransferUnit(_stateMachine.vigilant, unit);
        else if(_stateMachine.vigilant.Contains(unit) && !e.Defending())
        {
            _stateMachine.vigilant.TransferUnit(_stateMachine.engaged, unit);
            unit.gameObject.GetComponent<AudioController>().PlayEngageDisengage();
        }      
        _stateMachine.vigilantAspectsDisplay.SetAspect(_stateMachine.vigilant.CalcAspectSum());
        _stateMachine.engagedAspectsDisplay.SetAspect(_stateMachine.engaged.CalcAspectSum());

        yield break;
    }
}
