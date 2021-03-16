using System.Collections;

internal class DrawUnitState : State
{
    public DrawUnitState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override IEnumerator Start()
    {
        //check reshuffle\
        if (_stateMachine.preparingObject.transform.childCount == 0)
            _stateMachine.preparing.reshuffle(_stateMachine.recovering);
        //draw one from preparing into vigilant
        _stateMachine.DrawUnit();
        //update aspect display auto updates itsdelf
        _stateMachine.SetState(new NewEventState(_stateMachine));
        yield break;
    }
}