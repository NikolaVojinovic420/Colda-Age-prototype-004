using System.Collections;
using UnityEngine;

public class StartState : State
{
    public StartState(StateMachine sm) : base(sm)
    {
    }

    public override IEnumerator Start()
    {
        for (int i = 0; i < 5; i++)
        {
            _stateMachine.ReshuffleIfNeededAndDrawUnit();
        }
        
        _stateMachine.SetState(new DrawEventState(_stateMachine));

        yield break;
    }
}
