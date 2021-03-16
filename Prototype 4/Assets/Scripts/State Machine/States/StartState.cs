using System.Collections;
using UnityEngine;

public class StartState : State
{
    public StartState(StateMachine sm) : base(sm)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log($"start method call in StartState");

        for (int i = 0; i < 5; i++)
        {
            _stateMachine.DrawUnit();
        }

        _stateMachine.SetState(new DrawEventState(_stateMachine));

        yield break;
    }
}
