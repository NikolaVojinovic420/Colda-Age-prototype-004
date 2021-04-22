using System.Collections;
using UnityEngine;

public class StartState : State
{
    public StartState(StateMachine sm) : base(sm) {}

    public override IEnumerator Start()
    {
        _stateMachine.SetEventsRequirements();
        for (int i = 0; i < _stateMachine.vigilant.transform.childCount; i++)
        {
            Unit u = _stateMachine.vigilant.transform.GetChild(i).gameObject.GetComponent<Unit>();
            u.Transfer(_stateMachine.vigilant.transform, true);
            _stateMachine.vigilant.Add(u);
        }
        _stateMachine.AddEventsInHistory();
        _stateMachine.newConditionNReshuffle.SetActive(true);
        yield return new WaitForSeconds(0.7f);

        _stateMachine.future.Reshuffle(_stateMachine.history);

        _stateMachine.vigilantAspectsDisplay.SetAspect(_stateMachine.vigilant.CalcAspectSum());
        _stateMachine.engagedAspectsDisplay.SetAspect(new AspectMap());
        _stateMachine.DisplaySupplies();

        yield return new WaitForSeconds(1f);

        _stateMachine.SetState(new DrawEventState(_stateMachine));   
    }
}
