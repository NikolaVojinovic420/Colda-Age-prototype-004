using System.Collections;
using UnityEngine;

public class StartState : State
{
    public StartState(StateMachine sm) : base(sm) {}

    public override IEnumerator Start()
    {
        //for (int i = 0; i < 5; i++)
        //{
        //    _stateMachine.ReshuffleIfNeededAndDrawUnit();
        //}
        //for (int i = 0; i < _stateMachine.vigilant.transform.childCount; i++)
        //{
        //    _stateMachine.vigilant.Add(_stateMachine.vigilant.gameObject.transform.GetChild[i].GetComponent<Unit>());
        //}
        _stateMachine.vigilantAspectsDisplay.SetAspect(_stateMachine.vigilant.CalcAspectSum());
        _stateMachine.engagedAspectsDisplay.SetAspect(new AspectMap());

        _stateMachine.SetState(new DrawEventState(_stateMachine));

        yield break;
    }
}
