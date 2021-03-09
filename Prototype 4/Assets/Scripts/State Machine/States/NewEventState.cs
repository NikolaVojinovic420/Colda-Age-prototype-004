using System.Collections;

internal class NewEventState : State
{
    public NewEventState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override IEnumerator Start()
    {
        //if reshuffle needed
        //reshuffle
        //draw event to event stage
        _stateMachine.SetState(new PlayState(_stateMachine));
        yield break;
    }
}