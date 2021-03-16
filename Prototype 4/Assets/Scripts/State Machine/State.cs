using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class State
{
    protected StateMachine _stateMachine;

    public State(StateMachine stateMachine) { _stateMachine = stateMachine; }

    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator End()
    {
        yield break;
    }

    public virtual IEnumerator UnitClicked(Unit unit)
    {
        yield break;
    }
    public virtual IEnumerator ResponseClicked(Response eventResponse)
    {
        yield break;
    }
}
