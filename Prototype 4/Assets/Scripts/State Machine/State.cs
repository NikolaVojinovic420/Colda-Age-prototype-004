using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class State
{
    protected StateMachine _stateMachine;
    public State()
    {
    }
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
    public virtual void Engage(Unit unit)
    {

    }
    public virtual void Disengage(Unit unit)
    {

    }
    public virtual IEnumerator OnEventResponse(EventResponse eventResponse)
    {
        yield break;
    }
}
