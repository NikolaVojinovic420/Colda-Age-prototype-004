using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{
    public StartState(StateMachine sm) : base(sm) { }



    public override IEnumerator Start()
    {
        //create cards - deserialize
        _stateMachine.preparing.GetComponent<Deck>().Draw(_stateMachine.vigilant);
        _stateMachine.preparing.GetComponent<Deck>().Draw(_stateMachine.vigilant);
        _stateMachine.preparing.GetComponent<Deck>().Draw(_stateMachine.vigilant);
        _stateMachine.preparing.GetComponent<Deck>().Draw(_stateMachine.vigilant);
        _stateMachine.preparing.GetComponent<Deck>().Draw(_stateMachine.vigilant);
        Debug.Log($"started");
        _stateMachine.SetState(new NewEventState(_stateMachine));
        yield break;
    }

}
