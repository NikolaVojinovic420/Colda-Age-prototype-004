using System.Collections;
using UnityEngine;

public class StartState : State
{
    public StartState(StateMachine sm) : base(sm) {}

    public override IEnumerator Start()
    {
        //
        //for (int i = 0; i < 5; i++)
        //{
        //    _stateMachine.ReshuffleIfNeededAndDrawUnit();
        //}


        for (int i = 0; i < _stateMachine.vigilant.transform.childCount; i++)
        {
            Unit u = _stateMachine.vigilant.transform.GetChild(i).gameObject.GetComponent<Unit>();
            u.Transfer(_stateMachine.vigilant.transform, true);
            _stateMachine.vigilant.Add(u);
        }
        _stateMachine.vigilantAspectsDisplay.SetAspect(_stateMachine.vigilant.CalcAspectSum());
        _stateMachine.engagedAspectsDisplay.SetAspect(new AspectMap());

        _stateMachine.SetState(new DrawEventState(_stateMachine));

        yield break;
    }
}
