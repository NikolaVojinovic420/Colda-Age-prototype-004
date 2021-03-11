using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State _state;
    public GameObject vigilant;
    public GameObject engaged;
    public GameObject preparing;
    public GameObject recovering;
    public GameObject history;

    void  Awake()
    {
        Debug.Log("awake statemachine");
        _state = new StartState(this);
        //Debug.Log($"{_state.name}");
        if(_state == null)
            Debug.Log("state is null");
        _state.Start();
    }
    public void SetState(State state)
    {
        StartCoroutine(_state.End());
        _state = state;
        Debug.Log($"{_state} started");
        StartCoroutine(_state.Start());
    }
    public void OnResponse(EventResponse eventResponse) => _state.OnEventResponse(eventResponse);
    public void Engage(Unit unit) => _state.Engage(unit);
    public void Disengage(Unit unit) => _state.Disengage(unit);
}
