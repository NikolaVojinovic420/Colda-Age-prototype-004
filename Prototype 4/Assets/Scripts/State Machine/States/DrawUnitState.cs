using System.Collections;

public class DrawUnitState : State
{
    public DrawUnitState(StateMachine stateMachine) : base(stateMachine) {}

    public override IEnumerator Start()
    {
        //if (!_stateMachine.vigilant.IsFull())
        //{
        //    _stateMachine.ReshuffleIfNeededAndDrawUnit();
        //    
        //    _stateMachine.vigilantAspectsDisplay.SetAspect(_stateMachine.vigilant.CalcAspectSum());
        //}

        _stateMachine.SetState(new DrawEventState(_stateMachine));

        yield break;
    }
}
