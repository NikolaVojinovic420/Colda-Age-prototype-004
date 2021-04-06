using System;
using System.Collections;
using UnityEngine;

public class PlayState : State
{
    public PlayState(StateMachine stateMachine) : base(stateMachine) {}
    public override IEnumerator Start()
    {
        for (int i = 0; i < _stateMachine.vigilant.units.Length; i++)
        {
            Unit u = _stateMachine.vigilant.units[i];
            u.Recover(1);
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
        if (_stateMachine.engaged.Contains(unit))
            _stateMachine.engaged.TransferUnit(_stateMachine.vigilant, unit);
        else
            _stateMachine.vigilant.TransferUnit(_stateMachine.engaged, unit);

        _stateMachine.vigilantAspectsDisplay.SetAspect(_stateMachine.vigilant.CalcAspectSum());
        _stateMachine.engagedAspectsDisplay.SetAspect(_stateMachine.engaged.CalcAspectSum());

        yield break;
    }
}
