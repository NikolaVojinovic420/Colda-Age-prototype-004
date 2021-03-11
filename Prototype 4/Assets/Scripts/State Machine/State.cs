using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
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
        Debug.Log($"ss");
        yield return new WaitForSeconds(1);
        Debug.Log($"ss");
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
