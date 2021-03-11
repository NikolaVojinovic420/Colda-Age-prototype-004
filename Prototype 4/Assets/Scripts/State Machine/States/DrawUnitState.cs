using System.Collections;

internal class DrawUnitState : State
{
    public DrawUnitState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override IEnumerator Start()
    {
        //check reshuffle\
        if (_stateMachine.preparing.transform.childCount == 0)
            _stateMachine.preparing.GetComponent<Deck>().Reshuffle(_stateMachine.recovering.GetComponent<Deck>());
        //draw one from preparing into vigilant
        _stateMachine.preparing.GetComponent<Deck>().Draw(_stateMachine.vigilant);
        //update aspect display auto updates itsdelf
        _stateMachine.SetState(new NewEventState(_stateMachine));
        yield break;
    }
}