using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateMachine _stateMachine;
    public State(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator End()
    {
        yield break;
    }
    public virtual IEnumerator Engage(Unit unit)
    {
        yield break;
    }
    public virtual IEnumerator Disengage(Unit unit)
    {
        yield break;
    }
    public virtual IEnumerator OnEventResponse(EventResponse eventResponse)
    {
        yield break;
    }
}
